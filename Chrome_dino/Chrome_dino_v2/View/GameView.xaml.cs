using Chrome_dino_v2.Model;
using Chrome_dino_v2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chrome_dino_v2.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        private readonly Player player;
        private readonly Timer timer;
        private readonly EntitySetup entitySetup;
        private readonly IEntityFactory entityFactory;
        private List<IEntity> entities;
        private readonly FileModel fileModel;

        private int initSpawnDelay;

        public GameView(string game)
        {
            InitializeComponent();

            fileModel = FileModel.GetModel;

            entities = new List<IEntity>();

            //player
            player = new Player();

            entitySetup = new EntitySetup();

            //timer
            timer = new Timer(entitySetup.TimerSpeed, this);
            timer.Tick += LowerInitDelay;
            timer.Tick += GenerateEntity;
            timer.Tick += MoveEntities;
            timer.Tick += CheckFloor;
            timer.Tick += player.Update;
            timer.Tick += UpdateScore; 

            

            if (game != "")
            {
                initSpawnDelay = entitySetup.TimeToNext;
                SpawnEntities(game);
                timer.Start();
            }

            //Entity factory
            entityFactory = new RandomEntityFactory();

            timer.ResetTimeElapsed();
        }

        private void UpdateScore(object sender, TickEventArgs eventArgs)
        {
            LabelScore.Content = (eventArgs.TotalMsElapsed / 1000).ToString();
        }

        private void SpawnEntities(string game)
        {
            //load from file
            //construct entity
            //add: mainCanvas, entities
            var tempEntities = fileModel.LoadEntities(game);
            foreach (var item in tempEntities)
            {
                gameCanvas.Children.Add(item.Hitbox);
                entities.Add(item);
            }
            gameCanvas.Children.Add(player.Hitbox);
            player.ResetPossition();
        }

        private void LowerInitDelay(object sender, TickEventArgs eventArgs)
        {
            if (initSpawnDelay-- <= 0)
                timer.Tick -= LowerInitDelay;
        }

        private void GenerateEntity(object sender, TickEventArgs eventArgs)
        {
            if (initSpawnDelay > 0)
                return;

            var entity = entityFactory.Generate(eventArgs);
            if (entity != null)
            {
                Canvas.SetLeft(entity.Hitbox, Width);
                entity.X = Width;
                Canvas.SetBottom(entity.Hitbox, 0);
                entity.Y = 0;

                gameCanvas.Children.Add(entity.Hitbox);
                entities.Add(entity);
            }
        }

        private void MoveEntities(object sender, TickEventArgs eventArgs)
        {

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].CheckForEnd())
                {
                    gameCanvas.Children.Remove(entities[i].Hitbox);
                    entities.RemoveAt(i--);
                    continue;
                }


                if (entities[i].CheckColision(player))
                {
                    timer.Stop();
                }

                if (entities[i].Type == ElementType.ENEMY)
                {
                    for (int j = 0; j < entities.Count; j++)
                    {
                        if (i != j && entities[i].CheckColision(entities[j]))
                        {
                            entities[i].Accelerate(0, entitySetup.EnemyFlyVelocity);
                            break;
                        }
                    }
                }
                entities[i].Update();
            }
        }

        private void CheckFloor(object sender, TickEventArgs eventArgs)
        {
            bool floorSet = false;
            for (int i = 0; !floorSet && i < entities.Count; i++)
            {
                if (entities[i].Type == ElementType.OBSTACLE)
                    floorSet = player.CheckFloor(entities[i]);
            }
            if (floorSet == false)
                player.LevelGround = 0;
        }





        private void GameView_loaded(object sender, RoutedEventArgs e)
        {
            ClearValue(SizeToContentProperty);

            gameCanvas.ClearValue(WidthProperty);
            gameCanvas.ClearValue(HeightProperty);

            SetValue(MinWidthProperty, this.Width);
            SetValue(MinHeightProperty, this.Height);
            ButtonExit.IsEnabled = true;
            ButtonReset.IsEnabled = true;
            ButtonSave.IsEnabled = true;
        }

        private void GameViewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    player.MoveLeft = true;
                    break;
                case Key.Right:
                    player.MoveRight = true;
                    break;
                case Key.Up:
                    player.Accelerate(0, entitySetup.PlayerFlyVelocity);
                    break;
                case Key.Down:
                    player.Crawl(true);
                    break;
                default:
                    break;
            }
        }

        private void GameViewKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    player.MoveLeft = false;
                    break;
                case Key.Right:
                    player.MoveRight = false;
                    break;
                case Key.Down:
                    player.Crawl(false);
                    break;
                default:
                    break;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileModel.SaveEntities(entities);
                timer.Stop();
                MessageBox.Show("Game saved");
                timer.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 5; i < gameCanvas.Children.Count; i++)
            {
                gameCanvas.Children.RemoveAt(i--);
            }

            gameCanvas.Children.Add(player.Hitbox);

            //entities list
            entities = new List<IEntity>();

            player.ResetPossition();
            timer.ResetTimeElapsed();
            timer.Start();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GameWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Terminate();
        }
    }
}
/* */

using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chrome_dino_v2.Model
{
    public class Player : IElement
    {
        public ElementType Type => ElementType.PLAYER;
        public Rectangle Hitbox { get; }

        private readonly EntitySetup entitySetup;
        private double speedX;
        private double speedY;
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }

        public double X { get; private set; }
        public double Y { get; private set; }

        public double LevelGround { get; set; }
        public Player()
        {
            entitySetup = new EntitySetup();

            Hitbox = new Rectangle()
            {
                Width = entitySetup.PlayerWidth,
                Height = entitySetup.PlayerHeight,
                Fill = new SolidColorBrush(Colors.Black),
                StrokeThickness = 5,
                Stroke = new SolidColorBrush(Colors.BlueViolet)
            };
        }

        public void ResetPossition()
        {
            X = 10;
            Y = 120;

            speedX = 0;
            speedY = 0;

            Canvas.SetLeft(Hitbox, X);
            Canvas.SetBottom(Hitbox, Y);
        }



        public void Accelerate(double accelerationX, double accelerationY)
        {
            speedX += accelerationX;
            if (Y <= LevelGround || accelerationY <= 0)
                speedY += accelerationY;
        }

        public void Move(double velocityX, double velocityY)
        {
            X += velocityX;

            if (Y + speedY <= LevelGround)
                Y = LevelGround;
            else
                Y += velocityY;

            Canvas.SetLeft(Hitbox, X);
            Canvas.SetBottom(Hitbox, Y);
        }

        public void Update(object sender, TickEventArgs eventArgs)
        {
            if (MoveLeft && GreaterThanLeftBound())
                speedX = -entitySetup.PlayerMoveVelocity;
            else if (MoveRight && LessThanRightBound(entitySetup.SceneWidth))
                speedX = +entitySetup.PlayerMoveVelocity;
            else
                speedX = 0;

            Move(speedX, speedY);
            speedX *= entitySetup.Friction;
            speedY *= entitySetup.Friction;
            Accelerate(0, -entitySetup.Gravity);
        }


        public bool GreaterThanLeftBound()
        {
            double x = Canvas.GetLeft(Hitbox);
            return x > 0;
        }

        public bool LessThanRightBound(double sceneWidth)
        {
            double x = Canvas.GetLeft(Hitbox);
            return x < sceneWidth - Hitbox.Width;
        }

        public bool CheckFloor(IEntity entity)
        {
            double hitboxX = Canvas.GetLeft(Hitbox);
            double hitboxY = Canvas.GetBottom(Hitbox);
            double hitWidth = Hitbox.Width;

            double elementX = Canvas.GetLeft(entity.Hitbox);
            double elementY = Canvas.GetBottom(entity.Hitbox);
            double elWidth = entity.Hitbox.Width;
            double elHeight = entity.Hitbox.Height;

            if ((hitboxX + hitWidth > elementX && hitboxX + hitWidth < elementX + elWidth
                || hitboxX > elementX && hitboxX < elementX + elWidth)
                && hitboxY >= elementY + elHeight - 0.1)
            {
                LevelGround = entity.Hitbox.Height + entitySetup.ObstacleMarginHeight;
                return true;
            }
            return false;
        }


        public void Crawl(bool crawl)
        {
            if (crawl == true)
                Hitbox.Height = entitySetup.PlayerCrowl;
            else
                Hitbox.Height = entitySetup.PlayerHeight;
        }

    }
}


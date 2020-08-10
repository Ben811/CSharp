using Chrome_dino_v2.Model;
using Chrome_dino_v2.View;
using System.IO;
using System.Windows;

namespace Chrome_dino_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FileModel fileModel;

        public MainWindow()
        {
            InitializeComponent();

            fileModel = FileModel.GetModel;

            LoadSavedGames();
        }

        private void LoadSavedGames()
        {
            ListViewSavedGames.Items.Clear();
            ListViewSavedGames.Items.Add("None");
            var saves = fileModel.LoadSavedGames();
            foreach (var item in saves)
            {
                ListViewSavedGames.Items.Add(item);
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            GameView gameView;
            var index = ListViewSavedGames.SelectedIndex;
            if (index > 0)
                gameView = new GameView((string)ListViewSavedGames.Items[index]);
            else
                gameView = new GameView("");

            this.Hide();


            gameView.ShowDialog();
            LoadSavedGames();
            for (int i = 0; i < 100000000; i++) ;
            this.Show();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ClearValue(SizeToContentProperty);

            mainCanvas.ClearValue(WidthProperty);
            mainCanvas.ClearValue(HeightProperty);

            SetValue(MinWidthProperty, this.Width);
            SetValue(MinHeightProperty, this.Height);
        }

    }

}

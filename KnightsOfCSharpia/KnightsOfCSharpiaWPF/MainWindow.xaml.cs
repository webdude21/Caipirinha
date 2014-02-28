using System.Windows;
using System.Windows.Controls.Primitives;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            var charSelect = new CharacterSelect();
            this.Close();
            charSelect.Show();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            const double ratio = 0.618;
            if (sizeInfo.WidthChanged)
            {
                this.Width = sizeInfo.NewSize.Height / ratio;
            }
            else
            {
                this.Height = sizeInfo.NewSize.Width * ratio;
            }
        }

        private void MusicButton_Checked(object sender, RoutedEventArgs e)
        {
            Music.Music.Play();
        }

        private void MusicButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Music.Music.Close();
        }

        private void LoadSave_Click(object sender, RoutedEventArgs e)
        {
            LoadState loadGame = new LoadState(this);
            loadGame.Owner = this;
            loadGame.ShowDialog();
        }
    }
}

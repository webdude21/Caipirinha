using System.Windows;
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Items;

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
            InitilizeGameVariables();
        }

        public void InitilizeGameVariables()
        {
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            var charSelect = new CharacterSelect();
            this.Close();
            charSelect.Show();

            //BattleField battleField = new BattleField(new Mage("Pesho"));
            //this.Close();
            //battleField.Show();
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
    }
}

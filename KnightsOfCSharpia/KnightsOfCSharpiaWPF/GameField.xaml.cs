using KnightsOfCSharpiaLib.Creatures;
using System.IO;
using System.Windows;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : Window
    {
        public Hero Player { get; set; }

        public string GetStats
        {
            get { return this.Player.Statistics; }
        }

        public GameField(Hero player)
        {
            this.Player = player;
            InitializeComponent();
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

        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var inventory = new Inventory(Player);
            inventory.Show();
        }

        private void Battle_Click(object sender, RoutedEventArgs e)
        {
            BattleField battleField = new BattleField(this.Player);
            this.Close();
            battleField.Show();
        }

        private void SaveCharacter_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacterDialog saveDialog = new SaveCharacterDialog(this.Player);
            saveDialog.Owner = this;
            saveDialog.ShowDialog();
        }
    }
}

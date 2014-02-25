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
        public Hero Player { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitilizeGameVariables();
        }

        public void InitilizeGameVariables()
        {
            Player = new Warrior("Pesho");
            Player.Inventory.AddItem(new Boots("Кожени Ботуши", ItemRarity.Common));
            Player.Inventory.AddItem(new Belt("Кожен Колан", ItemRarity.Common));
            Player.Inventory.AddItem(new Gloves("Кожен ръкавици", ItemRarity.Common));
            Player.Inventory.AddItem(new Armour("Стоманена Броня", ItemRarity.Rare));
            Player.EquipItem(new Armour("Желязна Броня", ItemRarity.Rare));
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            var gamefield = new GameField(Player);
            this.Close();
            gamefield.Show();
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

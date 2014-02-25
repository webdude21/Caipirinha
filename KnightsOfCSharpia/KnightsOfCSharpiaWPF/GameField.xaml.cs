using KnightsOfCSharpiaLib.Creatures;
using System;
using System.Windows;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : Window
    {
        public Hero Player { get; set; }
        public GameField(Hero player)
        {
            InitializeComponent();
            this.Player = player;
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

        private void AttackButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DefendButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

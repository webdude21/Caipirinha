using KnightsOfCSharpiaLib.Creatures;
using System;
using System.Windows;
using KnightsOfCSharpiaLib.Engine;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : Window
    {
        public Hero Player { get; set; }
        public Creature Enemy { get; set; }

        public string GetStats
        {
            get { return this.Player.Statistics; }
        }
        public GameField(Hero player)
        {
            this.Player = player;
            InitializeComponent();
        }

        public void StartBattle()
        {
            Enemy = new EnemyMage("Gosho", 1, MageType.Icemage);
            var currentBattle = new BattleEngine(Player, Enemy);

            bool playerTurn = true;

            while (true)
            {
                string command = string.Empty;

                if (playerTurn)
                {
                    command = Console.ReadLine();
                    playerTurn = false;
                }
                else
                {
                    playerTurn = true;
                }

                Console.WriteLine(currentBattle.NextAttack(command));
            }
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

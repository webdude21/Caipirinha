using KnightsOfCSharpiaLib.Common;
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Engine;
using KnightsOfCSharpiaLib.Exceptions;
using System;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for BattleField.xaml
    /// </summary>
    public partial class BattleField : Window
    {
        private Hero playerHero;

        private Creature enemyCreature;

        IBattleSystem skirmish;

        public BattleField(Hero playerCharacter)
        {
            InitializeComponent();
            this.DataContext = this;
            this.playerHero = playerCharacter;

            this.PlayerCharacter.Source = new BitmapImage(new Uri(this.playerHero.GetImageName, UriKind.RelativeOrAbsolute));

            this.enemyCreature = RandomGenerator.GetRandomEnemy(playerCharacter.Level);

            this.EnemyCharacter.Source = new BitmapImage(new Uri(this.enemyCreature.GetImageName, UriKind.RelativeOrAbsolute));

            this.skirmish = new BattleEngine(this.playerHero, this.enemyCreature);
        }

        private string PlayerShortStatistics
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}\n", this.playerHero.Name);
                sb.AppendFormat("HP: {0}/{1}\n", this.playerHero.CurrentHealth, this.playerHero.MaxHealth);
                sb.AppendFormat("Mana: {0}/{1}\n", this.playerHero.CurrentMana, this.playerHero.MaxMana);

                return sb.ToString();
            }
        }

        private string EnemyShortStatistics
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}\n", this.enemyCreature.Name);
                sb.AppendFormat("HP: {0}/{1}\n", this.enemyCreature.CurrentHealth, this.enemyCreature.MaxHealth);
                sb.AppendFormat("Mana: {0}/{1}\n", this.enemyCreature.CurrentMana, this.enemyCreature.MaxMana);

                return sb.ToString();
            }
        }

        private void BasicAttackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NextSkirmish("basic");
        }

        private void SpecialAttackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NextSkirmish("special");
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
        private void NextSkirmish(string attackType)
        {
            try
            {
                string result = this.skirmish.NextAttack(attackType);
                this.PlayerBattleLog.Text = result;
                this.EnemyStatistics.Text = this.EnemyShortStatistics;

                result = this.skirmish.NextAttack(null);
                this.EnemyBattleLog.Text = result;
                this.PlayerStaistics.Text = this.PlayerShortStatistics;
            }
            catch (InsufficientManaException)
            {
                this.PlayerBattleLog.Text = "You don't have enough mana to cast this!";
            }
            catch (CombatantsDeadException)
            {
                if (!this.playerHero.IsAlive)
                {
                    MessageBox.Show("You are dead!", "Game over", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    MainWindow window = new MainWindow();
                    this.Close();
                    window.Show();
                }
                else
                {
                    this.playerHero.UpdateAfterBattle();
                    this.playerHero.AddXP(this.enemyCreature.XPYield);

                    var loot = RandomGenerator.GenerateRandomItem(this.playerHero.Level);

                    if (loot.Contents.Count != 0)
                    {
                        Loot lootField = new Loot(this.playerHero, loot);
                        lootField.ShowDialog();
                    }

                    GameField gameField = new GameField(this.playerHero);
                    this.Close();
                    gameField.Show();
                }
            }
        }
    }
}

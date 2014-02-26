using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Items;
using System.Windows;
using System.Windows.Input;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for CharacterSelect.xaml
    /// </summary>
    public partial class CharacterSelect : Window
    {
        public CharacterSelect()
        {
            InitializeComponent();
        }

        private string SelectedCharacter { get; set; }

        private void MageImage_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void MageImage_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void KnightImage_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void KnightImage_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void KnightImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.SelectedCharacter = "knight";
        }

        private void MageImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.SelectedCharacter = "mage";
        }

        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            bool errorFlag = false;

            if (string.IsNullOrWhiteSpace(this.SelectedCharacter))
            {
                MessageBox.Show("You must select a character!");
                errorFlag = true;
            }

            if (string.IsNullOrWhiteSpace(this.HeroName.Text))
            {
                MessageBox.Show("You must enter a valid name!");
                errorFlag = true;
            }

            if (!errorFlag)
            {
                Hero selectedChar;

                if (this.SelectedCharacter == "knight")
                {
                    selectedChar = new Warrior(this.HeroName.Text);
                    selectedChar.EquipItem(new Armour("Rusty chestpiece", ItemRarity.Common));
                    selectedChar.EquipItem(new Sword("Rusty sword", ItemRarity.Common));
                }
                else
                {
                    selectedChar = new Mage(this.HeroName.Text);
                    selectedChar.EquipItem(new Robe("Torn robe", ItemRarity.Common));
                    selectedChar.EquipItem(new Staff("Wooden stick", ItemRarity.Common));
                }

                GameField gameField = new GameField(selectedChar);
                gameField.Show();
                this.Close();
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
    }
}

using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for Loot.xaml
    /// </summary>
    public partial class Loot : Window
    {
        public Loot(Hero player, LootCollection contents)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Player = player;
            this.LootContainer = contents;
        }

        public Hero Player { get; set; }

        public LootCollection LootContainer { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.LootListBox.SelectedItem as Item;
            try
            {
                this.Player.Inventory.AddItem(selectedItem);
                this.LootContainer.RemoveItem(selectedItem);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "There's not enough space in the inventory to fit the item you're trying to take" +
                    " You can 'drop' something and then try again.",
                    "Item operation error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int slotsNeeded = this.LootContainer.Contents.Sum(x => x.Size);

            uint slotsAvailable = this.Player.Inventory.Capacity - this.Player.Inventory.UsedSize;

            if (slotsNeeded > slotsAvailable)
            {
                MessageBox.Show(
                                "There's not enough space in the inventory to fit the items you're trying to take" +
                                " You can 'drop' something and then try again.",
                    "Item operation error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                foreach (var item in this.LootContainer.Contents)
                {
                    this.Player.Inventory.AddItem(item);
                }

                this.LootContainer.Contents.Clear();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.InventoryListBox.SelectedItem as Item;

            this.Player.Inventory.RemoveItem(selectedItem);
        }
    }
}

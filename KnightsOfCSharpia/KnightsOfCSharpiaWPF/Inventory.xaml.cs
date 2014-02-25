using System;
using System.Windows;
using System.Windows.Data;
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Items;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory
    {
        public Hero Player { get; set; }

        public Inventory(Hero player)
        {
            InitializeComponent();
            this.Player = player;
            InventoryListBox.ItemsSource = Player.Inventory.InventoryContent;
            EquipmentListBox.ItemsSource = Player.Equipment.Items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EquipButtonClickItem(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (Item)InventoryListBox.SelectedItem;
                Player.EquipItem(selectedItem);
                Player.Inventory.RemoveItem(selectedItem);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "You can only equip one item of each type. You can unequip an item of the same type and equip the one you want.",
                    "Item operation error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }      
        }

        private void UnequipButtonClickItem(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (Item)EquipmentListBox.SelectedItem;
                Player.Inventory.AddItem(selectedItem);
                Player.UnEquipItem(selectedItem);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "There's not enough space in the inventory to fit the item you're trying to unequip" +
                    " You can 'drop' something and then try again.",
                    "Item operation error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        private void DropButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Item)InventoryListBox.SelectedItem;
            if (selectedItem != null)
            {
                Player.Inventory.RemoveItem(selectedItem);
            }
            else
            {
                selectedItem = (Item) EquipmentListBox.SelectedItem;
                Player.UnEquipItem(selectedItem);
            }
            
        }
    }
}

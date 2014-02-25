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
        public Hero player;

        public Inventory()
        {
            InitializeComponent();

            player = new Warrior("Pesho");
            player.Inventory.AddItem(new Boots("Кожени Ботуши", ItemRarity.Common));
            player.Inventory.AddItem(new Belt("Кожен Колан", ItemRarity.Common));
            player.Inventory.AddItem(new Gloves("Кожен ръкавици", ItemRarity.Common));
            player.Inventory.AddItem(new Armour("Стоманена Броня", ItemRarity.Rare));
            player.EquipItem(new Armour("Желязна Броня", ItemRarity.Rare));
            InventoryListBox.ItemsSource = player.Inventory.InventoryContent;
            EquipmentListBox.ItemsSource = player.Equipment.Items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EquipButtonClickItem(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (Item)InventoryListBox.SelectedItem;
                player.EquipItem(selectedItem);
                player.Inventory.RemoveItem(selectedItem);
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
                player.Inventory.AddItem(selectedItem);
                player.UnEquipItem(selectedItem);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "There's not enough space in the inventory to fit the item you're trying to unequip" +
                    " You can 'drop' something and then try again.",
                    "Item operation error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void EquipmentListBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            RefreshData();
        }

        private void InventoryListBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            EquipmentListBox.Items.Refresh();
            InventoryListBox.Items.Refresh();
        }

        private void DropButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Item)InventoryListBox.SelectedItem;
            if (selectedItem != null)
            {
                player.Inventory.RemoveItem(selectedItem);
            }
            else
            {
                selectedItem = (Item) EquipmentListBox.SelectedItem;
                player.UnEquipItem(selectedItem);
            }
            
        }
    }
}

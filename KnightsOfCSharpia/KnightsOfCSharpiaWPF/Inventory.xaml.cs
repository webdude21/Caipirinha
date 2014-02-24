using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Items;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory
    {
        public Inventory()
        {
            InitializeComponent();
                        var player = new Warrior("Pesho");
            player.Inventory.AddItem(new Boots("Кожени Ботуши", ItemRarity.Common));
            player.Inventory.AddItem(new Boots("Кожен боздуган", ItemRarity.Common));
            player.Inventory.AddItem(new Belt("Кожен Колан", ItemRarity.Common));
            player.EquipItem(new Armour("Желязна Броня", ItemRarity.Rare));
            InventoryListBox.ItemsSource = player.Inventory.InventoryContent;
            EquipmentListBox.ItemsSource = player.Equipment.Items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

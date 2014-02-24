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
using KnightsOfCSharpiaLib.Creatures;
using KnightsOfCSharpiaLib.Items;

namespace KnightsOfCSharpiaWPF
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : Window
    {
        public GameField()
        {
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
            var inventory = new Inventory();
            inventory.Show();
        }
    }
}

using KnightsOfCSharpiaLib.Creatures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for LoadState.xaml
    /// </summary>
    public partial class LoadState : Window
    {
        Window parent;
        
        public LoadState(Window parentWindow)
        {
            this.SaveNamesAndPath = new ObservableCollection<KeyValuePair<string, string>>();
            this.parent = parentWindow;

            InitializeComponent();
            if (Directory.Exists("saves"))
            {
                string[] savePaths = Directory.GetFiles("saves");

                foreach (string path in savePaths)
                {
                    string saveName = System.IO.Path.GetFileNameWithoutExtension(path);
                    this.SaveNamesAndPath.Add(new KeyValuePair<string, string>(saveName, path));
                }
            }

            this.DataContext = this;
        }

        public ObservableCollection<KeyValuePair<string, string>> SaveNamesAndPath { get; set; }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedPath = ((KeyValuePair<string, string>)this.SaveFilesListBox.SelectedItem).Value;

            string saveContents = File.ReadAllText(selectedPath);

            GameField newGame = new GameField(Hero.LoadState(saveContents));
            this.Close();
            this.parent.Close();
            newGame.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

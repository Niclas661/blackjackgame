using CardGameLib;
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

namespace BlackjackUI
{
    /// <summary>
    /// Interaction logic for PlayerAmountWindow.xaml
    /// </summary>
    public partial class PlayerAmountWindow : Window
    {
        public List<Player> players = new List<Player>();

        public PlayerAmountWindow()
        {
            InitializeComponent();
        }
        private void InitPlayers(int numOfPlayers)
        {
            for(int i = 0; i < numOfPlayers; i++)
            {
                players.Add(new Player());
            }

        }
        private void txtNumOfPlayers_Loaded(object sender, RoutedEventArgs e)
        {
            txtNumOfPlayers.TextChanged += TxtNumOfPlayers_TextChanged;
        }

        private void TxtNumOfPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnLoadP1.IsEnabled = false;
            btnLoadP2.IsEnabled = false;
            btnLoadP3.IsEnabled = false;
            btnLoadP4.IsEnabled = false;
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numOfPlayers = int.Parse(txtNumOfPlayers.Text);
                if(numOfPlayers <= 0)
                {
                    MessageBox.Show("There needs to be at least 1 player.");
                }
                else if(numOfPlayers > 4)
                {
                    MessageBox.Show("There can only be max 4 players.");
                }
                else
                {
                    switch (numOfPlayers)
                    {
                        case 1:
                            btnLoadP1.IsEnabled = true;

                            break;
                        case 2:
                            btnLoadP1.IsEnabled = true;
                            btnLoadP2.IsEnabled = true;
                            break;
                        case 3:
                            btnLoadP1.IsEnabled = true;
                            btnLoadP2.IsEnabled = true;
                            btnLoadP3.IsEnabled = true;
                            break;
                        case 4:
                            btnLoadP1.IsEnabled = true;
                            btnLoadP2.IsEnabled = true;
                            btnLoadP3.IsEnabled = true;
                            btnLoadP4.IsEnabled = true;
                            break;
                    }
                    InitPlayers(numOfPlayers);
                }
            }
            catch
            {
                MessageBox.Show("You have to type a number! At least 1 and max 4.");
            }

        }

        private void btnLoadP1_Click(object sender, RoutedEventArgs e)
        {
            OpenPlayerWindow(0);
        }
        private void OpenPlayerWindow(int index)
        {
            LoadPlayerWindow lpWindow = new LoadPlayerWindow(index);
            lpWindow.Owner = this;
            bool? valid = lpWindow.ShowDialog();
        }
        public void AddPlayer(int index, Player p)
        {
            players[index] = p;
        }

        private void btnLoadP2_Click(object sender, RoutedEventArgs e)
        {
            OpenPlayerWindow(1);
        }

        private void btnLoadP3_Click(object sender, RoutedEventArgs e)
        {
            OpenPlayerWindow(2);
        }

        private void btnLoadP4_Click(object sender, RoutedEventArgs e)
        {
            OpenPlayerWindow(3);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

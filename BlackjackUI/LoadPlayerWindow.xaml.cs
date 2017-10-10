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
    /// Interaction logic for LoadPlayerWindow.xaml
    /// </summary>
    public partial class LoadPlayerWindow : Window
    {
        public MainWindow AppMainWindow { get; set; }
        public int decks { get; set; }

        public Player p = new Player();
        bool playerLoaded = false;
        public List<Player> playerList;

        public LoadPlayerWindow()
        {
            InitializeComponent();

            btnCreateP1.Click += btnCreate_Click;
            btnCreateP2.Click += btnCreate_Click;
            btnCreateP3.Click += btnCreate_Click;
            btnCreateP4.Click += btnCreate_Click;

            btnLoadP1.Click += btnLoad_Click;
            btnLoadP2.Click += btnLoad_Click;
            btnLoadP3.Click += btnLoad_Click;
            btnLoadP4.Click += btnLoad_Click;
        }
         private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btnCreateP1":
                    if (txtPlayer1NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (!dbController.CheckPlayerExists(txtPlayer1NameInput.Text))
                        {
                            dbController.AddPlayer(txtPlayer1NameInput.Text);
                            MessageBox.Show("Player added");
                            p = dbController.GetPlayerByName(txtPlayer1NameInput.Text);
                            playerList[0] = p;
                        }
                        else
                        {
                            MessageBox.Show("This player name is already taken!");
                        }
                    }
                    break;
                case "btnCreateP2":
                    if (txtPlayer2NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (!dbController.CheckPlayerExists(txtPlayer2NameInput.Text))
                        {
                            dbController.AddPlayer(txtPlayer2NameInput.Text);
                            MessageBox.Show("Player added");
                            p = dbController.GetPlayerByName(txtPlayer2NameInput.Text);
                            playerList[1] = p;
                        }
                        else
                        {
                            MessageBox.Show("This player name is already taken!");
                        }
                    }
                    break;
                case "btnCreateP3":
                    if (txtPlayer3NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (!dbController.CheckPlayerExists(txtPlayer3NameInput.Text))
                        {
                            dbController.AddPlayer(txtPlayer3NameInput.Text);
                            MessageBox.Show("Player added");
                            p = dbController.GetPlayerByName(txtPlayer3NameInput.Text);
                            playerList[2] = p;
                        }
                        else
                        {
                            MessageBox.Show("This player name is already taken!");
                        }
                    }
                    break;
                case "btnCreateP4":
                    if (txtPlayer4NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (!dbController.CheckPlayerExists(txtPlayer4NameInput.Text))
                        {
                            dbController.AddPlayer(txtPlayer4NameInput.Text);
                            MessageBox.Show("Player added");
                            p = dbController.GetPlayerByName(txtPlayer4NameInput.Text);
                            playerList[3] = p;
                        }
                        else
                        {
                            MessageBox.Show("This player name is already taken!");
                        }
                    }
                    break;
            }
            CheckNullPlayers();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btnLoadP1":
                    if (txtPlayer1NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (dbController.CheckPlayerExists(txtPlayer1NameInput.Text))
                        {
                            p.Name = dbController.GetPlayerByName(txtPlayer1NameInput.Text).Name;
                            p.Money = dbController.GetPlayerMoneyByName(txtPlayer1NameInput.Text);
                            MessageBox.Show("Player loaded");
                            playerList[0] = p;
                            playerLoaded = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("This player name is already taken!");
                    }
                    break;
                case "btnLoadP2":
                    if (txtPlayer2NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (dbController.CheckPlayerExists(txtPlayer2NameInput.Text))
                        {
                            p.Name = dbController.GetPlayerByName(txtPlayer2NameInput.Text).Name;
                            p.Money = dbController.GetPlayerMoneyByName(txtPlayer2NameInput.Text);
                            MessageBox.Show("Player loaded");
                            playerList[1] = p;
                            playerLoaded = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("This player name is already taken!");
                    }
                    break;
                case "btnLoadP3":
                    if (txtPlayer3NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (dbController.CheckPlayerExists(txtPlayer3NameInput.Text))
                        {
                            p.Name = dbController.GetPlayerByName(txtPlayer3NameInput.Text).Name;
                            p.Money = dbController.GetPlayerMoneyByName(txtPlayer3NameInput.Text);
                            MessageBox.Show("Player loaded");
                            playerList[2] = p;
                            playerLoaded = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("This player name is already taken!");
                    }
                    break;
                case "btnLoadP4":
                    if (txtPlayer4NameInput.Text != null)
                    {
                        DbControl dbController = new DbControl();
                        if (dbController.CheckPlayerExists(txtPlayer4NameInput.Text))
                        {
                            p.Name = dbController.GetPlayerByName(txtPlayer4NameInput.Text).Name;
                            p.Money = dbController.GetPlayerMoneyByName(txtPlayer4NameInput.Text);
                            MessageBox.Show("Player loaded");
                            playerList[3] = p;
                            playerLoaded = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("This player name is already taken!");
                    }
                    break;
            }
            CheckNullPlayers();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void CheckNullPlayers()
        {
            btnClose.IsEnabled = true;
            for(int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i] == null)
                {
                    btnClose.IsEnabled = false;
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            
            if (playerLoaded)
            {
                //myW.AddPlayer(index, p);
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
            
           
            //Close();
        }

        private void cmbDecks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if(cmbDecks != null)
            {
                decks = cmbDecks.SelectedIndex + 1;
                CheckNullPlayers();
            }
            */
            
        }

        private void cmbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbPlayers.SelectedIndex)
            {
                case 0:
                    btnLoadP2.Visibility = Visibility.Hidden;
                    btnCreateP2.Visibility = Visibility.Hidden;
                    txtPlayer2NameInput.Visibility = Visibility.Hidden;
                    btnLoadP3.Visibility = Visibility.Hidden;
                    btnCreateP3.Visibility = Visibility.Hidden;
                    txtPlayer3NameInput.Visibility = Visibility.Hidden;
                    btnLoadP4.Visibility = Visibility.Hidden;
                    btnCreateP4.Visibility = Visibility.Hidden;
                    txtPlayer4NameInput.Visibility = Visibility.Hidden;
                    playerList = new List<Player>();
                    playerList.Add(null);

                    break;
                case 1:
                    btnLoadP2.Visibility = Visibility.Visible;
                    btnCreateP2.Visibility = Visibility.Visible;
                    txtPlayer2NameInput.Visibility = Visibility.Visible;
                    btnLoadP3.Visibility = Visibility.Hidden;
                    btnCreateP3.Visibility = Visibility.Hidden;
                    txtPlayer3NameInput.Visibility = Visibility.Hidden;
                    btnLoadP4.Visibility = Visibility.Hidden;
                    btnCreateP4.Visibility = Visibility.Hidden;
                    txtPlayer4NameInput.Visibility = Visibility.Hidden;
                    playerList = new List<Player>();
                    playerList.Add(null);
                    playerList.Add(null);

                    break;
                case 2:
                    btnLoadP2.Visibility = Visibility.Visible;
                    btnCreateP2.Visibility = Visibility.Visible;
                    txtPlayer2NameInput.Visibility = Visibility.Visible;
                    btnLoadP3.Visibility = Visibility.Visible;
                    btnCreateP3.Visibility = Visibility.Visible;
                    txtPlayer3NameInput.Visibility = Visibility.Visible;
                    btnLoadP4.Visibility = Visibility.Hidden;
                    btnCreateP4.Visibility = Visibility.Hidden;
                    txtPlayer4NameInput.Visibility = Visibility.Hidden;
                    playerList = new List<Player>();
                    playerList.Add(null);
                    playerList.Add(null);
                    playerList.Add(null);

                    break;
                case 3:
                    btnLoadP2.Visibility = Visibility.Visible;
                    btnCreateP2.Visibility = Visibility.Visible;
                    txtPlayer2NameInput.Visibility = Visibility.Visible;
                    btnLoadP3.Visibility = Visibility.Visible;
                    btnCreateP3.Visibility = Visibility.Visible;
                    txtPlayer3NameInput.Visibility = Visibility.Visible;
                    btnLoadP4.Visibility = Visibility.Visible;
                    btnCreateP4.Visibility = Visibility.Visible;
                    txtPlayer4NameInput.Visibility = Visibility.Visible;
                    playerList = new List<Player>();
                    playerList.Add(null);
                    playerList.Add(null);
                    playerList.Add(null);
                    playerList.Add(null);

                    break;
            }
            CheckNullPlayers();
        }
        //HOW DO WE REPRESENT PLAYERS? HOW DO WE LOAD THEM IN? HOW DO WE CREATE NEW ONES?
        //IN GUI
    }
}

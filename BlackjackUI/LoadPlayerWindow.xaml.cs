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

        public Player p = new Player();
        int index;
        bool playerLoaded = false;

        public LoadPlayerWindow(int index)
        {
            InitializeComponent();
            this.index = index;
        }
         private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if(txtPlayerNameInput.Text != null)
            {
                DbControl dbController = new DbControl();
                if (dbController.CheckPlayerExists(txtPlayerNameInput.Text))
                {
                    dbController.AddPlayer(txtPlayerNameInput.Text);
                    playerLoaded = true;
                }

            }
            else
            {
                MessageBox.Show("This player name is already taken!");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlayerNameInput.Text != null)
            {
                DbControl dbController = new DbControl();
                if (dbController.CheckPlayerExists(txtPlayerNameInput.Text))
                {
                    p.Name = dbController.GetPlayerByName(txtPlayerNameInput.Text).Name;
                    p.Money = dbController.GetPlayerMoneyByName(txtPlayerNameInput.Text);
                    playerLoaded = true;
                }

            }
            else
            {
                MessageBox.Show("This player name is already taken!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var myW = Owner as PlayerAmountWindow;
            myW.AddPlayer (index, p);
        }
        //HOW DO WE REPRESENT PLAYERS? HOW DO WE LOAD THEM IN? HOW DO WE CREATE NEW ONES?
        //IN GUI
    }
}

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
    /// Interaction logic for BetWindow.xaml
    /// </summary>
    public partial class BetWindow : Window
    {
        Player p = new Player();
        public int bet { get; set; }
        /// <summary>
        /// Constructor, requires a player
        /// </summary>
        /// <param name="player"></param>
        public BetWindow(Player player)
        {
            InitializeComponent();
            p = player;
        }
        /// <summary>
        /// Display player name and how much money he/she has
        /// </summary>
        private void SetupPlayerInfo()
        {
            lblPlayerBet.Content = $"How much would you like to bet {p.Name}?";
            lblAvailable.Content = $"${p.Money}";
        }
        /// <summary>
        /// Read bet and return dialogresult true if it's valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bet = int.Parse(txtBet.Text);
                DialogResult = true;
            }
            catch
            {
                MessageBox.Show("The bet is not valid!");
            }
        }
    }
}

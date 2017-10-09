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
using System.Windows.Navigation;
using System.Windows.Shapes;

using CardGameLib;

namespace BlackjackUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game currentGame;
        int playerTurnIndex = 0;
        bool gameOver = true;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Read suit and value of a card and return the relevant resource image for that card
        /// </summary>
        /// <param name="c">Card to be read</param>
        /// <returns></returns>
        private string CardImage(Card c)
        {
            string imgName = "";
            switch (c.Suit)
            {
                case Suit.Clubs:
                    imgName = "c";
                    break;
                case Suit.Diamonds:
                    imgName = "d";
                    break;
                case Suit.Hearts:
                    imgName = "h";
                    break;
                case Suit.Spades:
                    imgName = "s";
                    break;
            }
            if (c.Value < 11)
            {
                imgName += c.Value.ToString();
            }
            else if (c.Value == 11)
            {
                imgName += 1.ToString();
            }
            else if (c.Value == 12)
            {
                imgName += "j";
            }
            else if (c.Value == 13)
            {
                imgName += "q";
            }
            else if (c.Value == 14)
            {
                imgName += "k";
            }

            return imgName;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(gameOver)
                InitializeGame();
        }
        private void InitializeGame()
        {
            gameOver = false;
            lblDealerScore.Content = "DEALER";
            int players = cmbPlayers.SelectedIndex + 1;
            int decks = cmbDecks.SelectedIndex + 1;
            List<Player> playerList = new List<Player>();
            for (int x = 0; x < players; x++)
            {
                playerList.Add(new Player());
            }
            if(currentGame == null)
            {
                Game g = new Game(decks, playerList);
                currentGame = g;
            }
            else
            {
                ReinitializeGame();
            }
            btnHit.IsEnabled = true;
            btnStand.IsEnabled = true;
            btnReshuffle.IsEnabled = false;
            btnPlay.IsEnabled = false;

            for (int i = 0; i < currentGame.PlayerCount; i++)
            {
                UpdatePlayerHand(i, 0);
                UpdatePlayerHand(i, 1);

            }
            UpdateDealerHand(0);
            UpdatePlayerTurnText();
        }
        private void ReinitializeGame()
        {
            playerTurnIndex = 0;
            currentGame.RestartGame();

            #region changecardsback
            p10.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p11.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p12.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p13.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p14.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p20.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p21.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p22.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p23.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p24.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p30.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p31.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p32.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p33.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p34.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p40.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p41.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p42.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p43.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            p44.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            d10.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            d11.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            d12.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            d13.Source = new BitmapImage(new Uri("Resources/b1fv.png", UriKind.Relative));
            #endregion
            #region lblChange
            lblPlayer1Score.Foreground = Brushes.Black;
            lblPlayer1Score.Background = Brushes.White;
            lblPlayer2Score.Foreground = Brushes.Black;
            lblPlayer2Score.Background = Brushes.White;
            lblPlayer3Score.Foreground = Brushes.Black;
            lblPlayer3Score.Background = Brushes.White;
            lblPlayer4Score.Foreground = Brushes.Black;
            lblPlayer4Score.Background = Brushes.White;
            #endregion
        }

        private void UpdatePlayerHand(int playerIndex, int turn)
        {
            Card c = currentGame.PlayerInfo(playerIndex).Hand.Cards[turn];

            switch (playerIndex)
            {
                case 0:
                    #region player1
                    if(turn == 0)
                    {
                        p10.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if(turn == 1)
                    {
                        p11.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 2)
                    {
                        p12.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 3)
                    {
                        p13.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 4)
                    {
                        p14.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Reached limit.");
                    }
                    #endregion
                    SetPlayerScoreText(0);
                    break;
                case 1:
                    #region player2
                    if (turn == 0)
                    {
                        p20.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 1)
                    {
                        p21.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 2)
                    {
                        p22.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 3)
                    {
                        p23.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 4)
                    {
                        p24.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Reached limit.");
                    }
                    #endregion
                    //lblPlayer2Score.Content = currentGame.PlayerInfo(1).Hand.CalcValue();
                    SetPlayerScoreText(1);
                    break;
                case 2:
                    #region player3
                    if (turn == 0)
                    {
                        p30.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 1)
                    {
                        p31.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 2)
                    {
                        p32.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 3)
                    {
                        p33.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 4)
                    {
                        p34.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Reached limit.");
                    }
                    #endregion
                    //lblPlayer3Score.Content = currentGame.PlayerInfo(2).Hand.CalcValue();
                    SetPlayerScoreText(2);
                    break;
                case 3:
                    #region player4
                    if (turn == 0)
                    {
                        p40.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 1)
                    {
                        p41.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 2)
                    {
                        p42.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 3)
                    {
                        p43.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else if (turn == 4)
                    {
                        p44.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Reached limit.");
                    }
                    #endregion
                    //lblPlayer4Score.Content = currentGame.PlayerInfo(3).Hand.CalcValue();
                    SetPlayerScoreText(3);
                    break;
            }
            
        }
        private void UpdateDealerHand(int turn)
        {
            Card c = currentGame.DealerInfo().Hand.Cards[turn];

            if (turn == 0)
                {
                    d10.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                }
                else if (turn == 1)
                {
                    d11.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                }
                else if (turn == 2)
                {
                    d12.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                }
                else if (turn == 3)
                {
                    d13.Source = new BitmapImage(new Uri("Resources/" + CardImage(c) + ".png", UriKind.Relative));
                }
        }

        private bool CheckEligible(int numOfPlayers)
        {
            if (currentGame != null)
            {
                MessageBox.Show("You cannot start a new game when one is already started!");
                return false;
            }
            else if (numOfPlayers >= 5)
            {
                MessageBox.Show("No more than 4 players can play at this \"table\".");
                return false;
            }
            else if(numOfPlayers == 0)
            {
                MessageBox.Show("At least one player has to play!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            currentGame.DealPlayer(playerTurnIndex);
            UpdatePlayerHand(playerTurnIndex, currentGame.PlayerInfo(playerTurnIndex).Hand.NumOfCards - 1);

            if(currentGame.PlayerInfo(playerTurnIndex).Bust == true || currentGame.PlayerInfo(playerTurnIndex).Stands == true)
            {
                SetPlayerScoreText(playerTurnIndex);
                FindNextPlayerToPlay();
            }
        }
        private void SetPlayerScoreText(int index)
        {
            switch (index)
            {
                case 0:
                    lblPlayer1Score.Content = currentGame.PlayerInfo(0).Hand.CalcValue();
                    if(currentGame.PlayerInfo(0).Bust)
                    {
                        lblPlayer1Score.Content += " (BUST)";
                        lblPlayer1Score.Background = Brushes.Red;
                        lblPlayer1Score.Foreground = Brushes.White;
                    }
                    else if (currentGame.PlayerInfo(0).Stands)
                        lblPlayer1Score.Content += " (STAND)";
                    break;
                case 1:
                    lblPlayer2Score.Content = currentGame.PlayerInfo(1).Hand.CalcValue();
                    if (currentGame.PlayerInfo(1).Bust)
                    {
                        lblPlayer2Score.Content += " (BUST)";
                        lblPlayer2Score.Background = Brushes.Red;
                        lblPlayer2Score.Foreground = Brushes.White;
                    }
                    else if (currentGame.PlayerInfo(1).Stands)
                        lblPlayer2Score.Content += " (STAND)";
                    break;
                case 2:
                    lblPlayer3Score.Content = currentGame.PlayerInfo(2).Hand.CalcValue();
                    if (currentGame.PlayerInfo(2).Bust)
                    {
                        lblPlayer3Score.Content += " (BUST)";
                        lblPlayer3Score.Background = Brushes.Red;
                        lblPlayer3Score.Foreground = Brushes.White;
                    }
                    else if (currentGame.PlayerInfo(2).Stands)
                        lblPlayer3Score.Content += " (STAND)";
                    break;
                case 3:
                    lblPlayer4Score.Content = currentGame.PlayerInfo(3).Hand.CalcValue();
                    if (currentGame.PlayerInfo(3).Bust)
                    {
                        lblPlayer4Score.Content += " (BUST)";
                        lblPlayer4Score.Background = Brushes.Red;
                        lblPlayer4Score.Foreground = Brushes.White;

                    }

                    else if (currentGame.PlayerInfo(3).Stands)
                        lblPlayer4Score.Content += " (STAND)";
                    break;
            }
        }

        private void UpdatePlayerTurnText()
        {
            lblTurn.Content = $"Player {playerTurnIndex+1} turn";
        }

        private void btnStand_Click(object sender, RoutedEventArgs e)
        {
            currentGame.PlayerStands(playerTurnIndex);
            SetPlayerScoreText(playerTurnIndex);
            FindNextPlayerToPlay();
            

        }
        private void FindNextPlayerToPlay()
        {
            if (currentGame.AllPlayersBust())
            {
                GameOver();
                return;
            }
            bool foundPlayerNotBusted = false;
            while (!foundPlayerNotBusted)
            {
                playerTurnIndex++;
                if(playerTurnIndex >= currentGame.PlayerCount)
                {
                    //dealers turn
                    UpdateDealerHand(1);
                    foundPlayerNotBusted = true;
                    DealerPhase();
                }
                else if(currentGame.PlayerInfo(playerTurnIndex).Bust == false)
                {
                    foundPlayerNotBusted = true;
                    UpdatePlayerTurnText();
                }
            }
        }

        private void GameOver()
        {
            MessageBox.Show("Game over");
            btnHit.IsEnabled = false;
            btnStand.IsEnabled = false;
            btnReshuffle.IsEnabled = true;
            btnPlay.IsEnabled = true;
            gameOver = true;

            if (currentGame.DealerInfo().Bust)
            {
                MessageBox.Show("Dealer went bust!");
            }

            WinCondition[] scoreboard = currentGame.PlayersWon();
            string winMsg = "";
            string tieMsg = "";
            bool noWin = true;
            bool noTie = true;
            for(int i = 0; i < scoreboard.Length; i++)
            {
                if(scoreboard[i] == WinCondition.WIN)
                {
                    noWin = false;
                    winMsg += "Player " + (i+1) + " ";
                }
                if (scoreboard[i] == WinCondition.TIE)
                {
                    noTie = false;
                    tieMsg += "Player " + (i+1) + " ";
                }
            }
            if (noWin)
            {
                winMsg += "Dealer wins!";
            }
            else
            {
                winMsg += "wins!";
            }
            if (!noTie)
            {
                tieMsg += "ties with the dealer.";
            }

            MessageBox.Show(winMsg + " " + tieMsg);

        }

        private void DealerPhase()
        {
            currentGame.DealerMove();
            for(int i = 2; i < currentGame.DealerInfo().Hand.NumOfCards; i++)
            {
                UpdateDealerHand(i);
            }
            UpdateDealerScore();
            GameOver();
        }
        private void UpdateDealerScore()
        {
            if (currentGame.DealerInfo().Bust == true)
            {
                lblDealerScore.Content = $"{currentGame.DealerInfo().Hand.CalcValue()} (BUST)";
            }
            else
            {
                lblDealerScore.Content = $"{currentGame.DealerInfo().Hand.CalcValue()}";
            }
        }

        private void btnReshuffle_Click(object sender, RoutedEventArgs e)
        {
            currentGame.Reshuffle();
            MessageBox.Show("The deck has been reshuffled");
        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < currentGame.PlayerCount; i++)
            {
                MessageBox.Show("Player " + (i + 1) + ": Cards=" + currentGame.PlayerInfo(i).Hand.NumOfCards + ", Value=" + currentGame.PlayerInfo(i).Hand.CalcValue());
            }
            MessageBox.Show("Dealer: Cards=" + currentGame.DealerInfo().Hand.NumOfCards + ", Value=" + currentGame.DealerInfo().Hand.CalcValue());
        }

        private void cmbDecks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameOver)
            {
                currentGame = null;
            }
        }

        private void cmbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameOver)
            {
                currentGame = null;
            }
        }

        private void btnBetLoadPlayer1_Click(object sender, RoutedEventArgs e)
        {
            LoadPlayerWindow(0);
        }

        private void LoadPlayerWindow(int index)
        {
            LoadPlayerWindow lpWindow = new LoadPlayerWindow(index);
            lpWindow.Owner = this;
            lpWindow.ShowDialog();
        }

        public void LoadPlayer(Player p, int index)
        {
            currentGame.ReplacePlayer(index, p);
        }

        private void btnBetLoadPlayer2_Click(object sender, RoutedEventArgs e)
        {
            LoadPlayerWindow(1);
        }

        private void btnBetLoadPlayer3_Click(object sender, RoutedEventArgs e)
        {
            LoadPlayerWindow(2);
        }

        private void btnBetLoadPlayer4_Click(object sender, RoutedEventArgs e)
        {
            LoadPlayerWindow(3);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PlayerAmountWindow paWindow = new PlayerAmountWindow();
            paWindow.ShowDialog();
        }
    }
}

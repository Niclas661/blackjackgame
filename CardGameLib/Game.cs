using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public enum WinCondition
    {
        WIN,
        LOSE,
        TIE
    }
    /// <summary>
    /// Niclas Svensson
    /// 2018-09-15
    /// 
    /// The GUI interacts with the game class to create moves and make decisions in a game
    /// </summary>
    public class Game
    {
        List<Player> players;
        Dealer dealer = new Dealer();
        int decks = 0;

        /// <summary>
        /// Return the amount of players in the game
        /// </summary>
        public int PlayerCount
        {
            get
            {
                return players.Count;
            }
        }

        
        
        
        CombinedDeck deck;
        /// <summary>
        /// Create a new game with X amount of players and decks
        /// </summary>
        /// <param name="decks"></param>
        /// <param name="players"></param>
        public Game(int decks, List<Player> players)
        {


            this.players = players;
            this.decks = decks;
            List<Deck> deckList = new List<Deck>();
            for(int i = 0; i < decks; i++)
            {
                deckList.Add(new Deck());
            }

            deck = new CombinedDeck(deckList);

            StartGame();

        }

        public Game()
        {

        }


        /// <summary>
        /// Reshuffle the deck
        /// </summary>
        /// <param name="decks"></param>
        public void Reshuffle()
        {
            List<Deck> deckList = new List<Deck>();
            for (int i = 0; i < decks; i++)
            {
                deckList.Add(new Deck());
            }

            deck = new CombinedDeck(deckList);
            RestartGame();
        }
        /// <summary>
        /// Start a game and deal two cards to each dealer
        /// </summary>
        private void StartGame()
        {
            //two initial cards for all players
            DealAllPlayers();
            DealAllPlayers();

            DealDealer();
            DealDealer();
        }
        /// <summary>
        /// Deal a card to a player
        /// </summary>
        /// <param name="index"></param>
        public void DealPlayer(int index)
        {
            players[index].DealCard(deck.Draw());
            if(players[index].Hand.CalcValue() == 21)
            {
                players[index].Stands = true;
            }
            else if(players[index].Hand.CalcValue() > 21)
            {
                players[index].Bust = true;
            }
        }
        /// <summary>
        /// Deal a card to all players (except dealer)
        /// </summary>
        public void DealAllPlayers()
        {
            foreach(Player player in players)
            {
                player.DealCard(deck.Draw());
            }
        }

        /// <summary>
        /// Deal a card to the dealer
        /// </summary>
        public void DealDealer()
        {
            dealer.DealCard(deck.Draw());
        }

        /// <summary>
        /// Return player object
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Player PlayerInfo(int index)
        {
            return players[index];
        }

        /// <summary>
        /// Return dealer object
        /// </summary>
        /// <returns></returns>
        public Player DealerInfo()
        {
            return dealer;
        }

        /// <summary>
        /// Return info whether the player of interest is standing
        /// </summary>
        /// <param name="index"></param>
        public void PlayerStands(int index)
        {
            players[index].Stands = true;
        }

        /// <summary>
        /// Check if all players have gone bust
        /// </summary>
        /// <returns></returns>
        public bool AllPlayersBust()
        {
            for(int i = 0; i < players.Count; i++)
            {
                if (players[i].Bust == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void DealerMove()
        {
            while (!dealer.Stands)
            {
                DealDealer();
            }
        }
        /// <summary>
        /// Empty all players and dealer's hands of cards (this makes the cards go away and can only come back through creating a new combineddeck)
        /// </summary>
        public void RestartGame()
        {
            for(int i = 0; i < PlayerCount; i++)
            {
                players[i].Reset();
            }
            dealer = new Dealer();
            StartGame();
        }
        /// <summary>
        /// Return an array of the players who won, lost or tied with the dealer
        /// </summary>
        /// <returns></returns>
        public WinCondition[] PlayersWon()
        {
            WinCondition[] playersWL = new WinCondition[PlayerCount];
            for(int i = 0; i < PlayerCount; i++)
            {
                if (players[i].Bust)
                {
                    playersWL[i] = WinCondition.LOSE;
                }
                else if(players[i].Hand.CalcValue() > dealer.Hand.CalcValue() && players[i].Hand.CalcValue() <= 21)
                {
                    playersWL[i] = WinCondition.WIN;
                }
                else if (dealer.Bust && players[i].Hand.CalcValue() <= 21)
                {
                    playersWL[i] = WinCondition.WIN;
                }

                else if (players[i].Hand.CalcValue() < dealer.Hand.CalcValue())
                {
                    playersWL[i] = WinCondition.LOSE;
                }
                else if(players[i].Hand.CalcValue() == dealer.Hand.CalcValue())
                {
                    playersWL[i] = WinCondition.TIE;
                }
            }
            return playersWL;
        }

        /// <summary>
        /// Replace the player at that "seat" with a new player
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="p">New player object</param>
        public void ReplacePlayer(int index, Player p)
        {
            players[index] = p;
        }
    }
}

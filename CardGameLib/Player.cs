using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public class Player
    {
        public Hand Hand { get; set; } = new Hand();
        public bool Stands { get; set; }
        public bool Bust { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int Bet { get; set; }

        public void DealCard(Card card)
        {
            if (!Stands || Hand.CalcValue() > 21 || !Bust)
            {
                Hand.AddCard(card);
                if(Hand.CalcValue() > 21)
                {
                    Bust = true;
                }
                if(Hand.CalcValue() == 21)
                {
                    Stands = true;
                }
            }
            
        }

        internal void Reset()
        {
            Hand = new Hand();
            Stands = false;
            Bust = false;
            Bet = 0;
        }
        /// <summary>
        /// Remove the bet from player's money
        /// </summary>
        public void SubtractMoney()
        {
            Money -= Bet;
        }
        /// <summary>
        /// Add double the bet to the player's money
        /// </summary>
        public void AddMoneyWin()
        {
            Money += Bet * 2;
        }
        /// <summary>
        /// Give the player his bet back
        /// </summary>
        public void AddMoneySplit()
        {
            Money += Bet;
        }
       
    }
}

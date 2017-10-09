using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    /// <summary>
    /// Niclas Svensson
    /// 2018-09-15
    /// 
    /// The Hand class contains the cards that a hand has and can give info like having an ace or soft hand
    /// </summary>
    public class Hand
    {
        public List<Card> Cards = new List<Card>();
        bool hasAce = false;
        public bool softHand { get; set; } = false;

        /// <summary>
        /// Add a card to the hand
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
        /// <summary>
        /// Calculate the score the player has
        /// </summary>
        /// <returns></returns>
        public int CalcValue()
        {
            int score = 0;
            
            foreach(Card c in Cards)
            {
                if(c.Value <= 10)
                {
                    score += c.Value;
                }
                //if the card is an ace
                else if(c.Value == 11)
                {
                    //if the player already has an ace in his hand
                    if(hasAce && c.Value + 11 > 21)
                    {
                        score += 1;
                    }
                    //if ace (11) + current score > 21, its a soft hand and add 1 point
                    else if(!hasAce && c.Value + score > 21)
                    {
                        score += 1;
                        softHand = true;
                    }
                    else if(!hasAce && c.Value + score <= 21)
                    {
                        score += 11;
                        hasAce = true;
                    }
                    else
                    {
                        score += 11;
                        hasAce = true;
                    }
                }
                //face cards are valued at 10
                else if(c.Value > 11)
                {
                    score += 10;
                }
            }
            return score;
        }
        /// <summary>
        /// Get the number of cards in the hand
        /// </summary>
        public int NumOfCards
        {
            get { return Cards.Count; }
        }
    }
}

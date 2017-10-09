using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public enum Suit
    {
        Diamonds,
        Hearts,
        Clubs,
        Spades
    }
    /// <summary>
    /// Niclas Svensson
    /// 2018-09-15
    /// 
    /// The Card class contains info about its suit and value
    /// </summary>
    public class Card
    {
        public Suit Suit { get; set; }
        public int Value { get; set; }
        
        /// <summary>
        /// Return the display name of the card (Ace of Hearts for example)
        /// </summary>
        public string DisplayName
        {
            get
            {
                if(Value == 11)
                {
                    return "Ace of " + Suit;
                }
                else if (Value == 12)
                {
                    return "Jack of " + Suit;
                }
                else if (Value == 13)
                {
                    return "Queen of " + Suit;
                }
                else if (Value == 14)
                {
                    return "King of " + Suit;
                }
                else
                {
                    return Value.ToString() + " of " + Suit;
                }
            }
        }
    }
}

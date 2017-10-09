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
    /// The Player class contains an instance of a Hand and has info about a player stands or busts
    /// </summary>
    public class Player
    {
        public Hand Hand { get; } = new Hand();
        public bool Stands { get; set; }
        public bool Bust { get; set; }

        /// <summary>
        /// Deal a card to the player
        /// 
        /// If the hand value passes 21, then the player busts
        /// If the hand value is 21, then the player automatically stands
        /// </summary>
        /// <param name="card"></param>
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
    }
}

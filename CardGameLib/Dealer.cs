using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public class Dealer : Player
    {
        public bool hiddenCard { get; set; } = true;

        public new void DealCard(Card card)
        {

            if (!Stands || Hand.CalcValue() < 21)
            {
                Hand.AddCard(card);
                //in this game, the dealer stands on soft 17
                if (Hand.CalcValue() == 17 && Hand.softHand)
                {
                    Stands = true;
                }
                else if(Hand.CalcValue() > 17)
                {
                    Stands = true;
                }
                if (Hand.CalcValue() > 21)
                {
                    Bust = true;
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameLib;

namespace BlackjackUI
{
    /// <summary>
    /// A helper class to select the right card image for a certain card
    /// </summary>
    public class CardVisualizer
    {
        public string CardImage(Suit suit, int value)
        {
            string imgName = "";
            switch (suit)
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
            if(value < 11)
            {
                imgName += value.ToString();
            }
            //the ace cards png's is named h1, c1 so forth, so add 1 to the end rather than 11
            else if (value == 11)
            {
                imgName += 1.ToString();
            }


            return imgName;
        }
    }
}

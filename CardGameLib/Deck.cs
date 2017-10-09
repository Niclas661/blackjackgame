using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public class Deck
    {
        Card[] Cards = new Card[52];

        public Deck()
        {
            Shuffle();
        }

        //debug only, remove at submission
        public Card GetCardAt(int index)
        {
            return Cards[index];
        }

        public Card HandOutCard()
        {
            Card picked = Cards[NumOfCardsInDeck-1];
            Cards = Cards.Where(x => x != picked).ToArray();

            return picked;
        }

        public int NumOfCardsInDeck
        {
            get
            {
                return Cards.Length;
            }
        }

        public void Shuffle()
        {
            //reset deck
            Cards = new Card[52];

            int currentStackVal = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                //Go through values 2-14 (ace is 11)
                for (int x = 2; x < 15; x++)
                {
                    Card newCard = new Card();
                    newCard.Suit = suit;
                    newCard.Value = x;
                    //add card to deck
                    Cards[currentStackVal] = newCard;
                    currentStackVal++;
                }
            }

            Random randomize = new Random();
            Cards = Cards.OrderBy(x => randomize.Next()).ToArray();
        }
    }
}

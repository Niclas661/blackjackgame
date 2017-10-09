using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public class CombinedDeck
    {
        List<Card> deck = new List<Card>();
        int numOfDecks = 0;

        public CombinedDeck(List<Deck> decks)
        {
            for(int i = 0; i < decks.Count; i++)
            {
                for(int card = 0; card < decks[i].NumOfCardsInDeck; card++)
                {
                    deck.Add(decks[i].GetCardAt(card));
                    numOfDecks++;
                }
            }
        }
        private void CreateNewDeck(List<Deck> decks)
        {
            for (int i = 0; i < decks.Count; i++)
            {
                for (int card = 0; card < decks[i].NumOfCardsInDeck; card++)
                {
                    deck.Add(decks[i].GetCardAt(card));
                    numOfDecks++;
                }
            }
        }
        public void Shuffle()
        {
            Random r = new Random();
            deck = deck.OrderBy(x => r.Next()).ToList();
        }
        public Card Draw()
        {
            Card picked = null;
            try
            {
                picked = deck.Last();
                
            }
            catch
            {
                //create new deck if no more cards exist
                List<Deck> decks = new List<Deck>();
                for(int i = 0; i < numOfDecks; i++)
                {
                    decks.Add(new Deck());
                }
                CreateNewDeck(decks);
                picked = deck.Last();
            }
            deck.RemoveAt(deck.Count - 1);
            return picked;

        }
        /// <summary>
        /// Return all cards from outside the deck and reshuffle
        /// 
        /// This needs to work if no cards are created outside the deck (zero-sum kind of deal)
        /// </summary>
        /// <param name="hands"></param>
        public void Reset(List<Hand> hands)
        {
            List<Card> cards = new List<Card>();
            for (int x = 0; x < hands.Count; x++)
            {
                cards = hands[x].Cards;
            }
            foreach(Card card in cards)
            {
                deck.Add(card);
            }
            Shuffle();
        }
    }
}

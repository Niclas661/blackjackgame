using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib
{
    public class Player
    {
        public Hand Hand { get; } = new Hand();
        public bool Stands { get; set; }
        public bool Bust { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }

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

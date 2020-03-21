using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Player
    {

        Card[] hand = new Card[2];

        public Player()
        {
        }

        public void AddCard(Card card)
        {
            if (hand[0] == null)
                hand[0] = card;
            else
                hand[1] = card;
        }

        public Card[] GetHand()
        {
            return hand;
        }
    }
}

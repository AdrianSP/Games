using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card
    {

        private bool isDealt = false;
        private CardName name;
        private Suit suit;
        private bool isAce = false;

        public Card(CardName name, Suit suit)
        {
            this.name = name;
            this.suit = suit;
            if (name == CardName.Ace)
                isAce = true;
        }

        public bool GetIsDealt()
        {
            return isDealt;
        }

        public void SetIsDealt()
        {
            isDealt = true;
        }

        public CardName GetCardName()
        {
            return name;
        }

        public Suit GetSuit()
        {
            return suit;
        }

        public bool GetIsAce()
        {
            return isAce;
        }

    }
}

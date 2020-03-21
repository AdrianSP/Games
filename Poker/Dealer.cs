using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Dealer
    {

        private static Dealer _instance;

        private List<Card> deck = new List<Card>
        {
            new Card(CardName.Ace, Suit.Spades), new Card(CardName.Ace, Suit.Clubs), new Card(CardName.Ace, Suit.Hearts), new Card(CardName.Ace, Suit.Diamonds),
            new Card(CardName.Two, Suit.Spades), new Card(CardName.Two, Suit.Clubs), new Card(CardName.Two, Suit.Hearts), new Card(CardName.Two, Suit.Diamonds),
            new Card(CardName.Three, Suit.Spades), new Card(CardName.Three, Suit.Clubs), new Card(CardName.Three, Suit.Hearts), new Card(CardName.Three, Suit.Diamonds),
            new Card(CardName.Four, Suit.Spades), new Card(CardName.Four, Suit.Clubs), new Card(CardName.Four, Suit.Hearts), new Card(CardName.Four, Suit.Diamonds),
            new Card(CardName.Five, Suit.Spades), new Card(CardName.Five, Suit.Clubs), new Card(CardName.Five, Suit.Hearts), new Card(CardName.Five, Suit.Diamonds),
            new Card(CardName.Six, Suit.Spades), new Card(CardName.Six, Suit.Clubs), new Card(CardName.Six, Suit.Hearts), new Card(CardName.Six, Suit.Diamonds),
            new Card(CardName.Seven, Suit.Spades), new Card(CardName.Seven, Suit.Clubs), new Card(CardName.Seven, Suit.Hearts), new Card(CardName.Seven, Suit.Diamonds),
            new Card(CardName.Eight, Suit.Spades), new Card(CardName.Eight, Suit.Clubs), new Card(CardName.Eight, Suit.Hearts), new Card(CardName.Eight, Suit.Diamonds),
            new Card(CardName.Nine, Suit.Spades), new Card(CardName.Nine, Suit.Clubs), new Card(CardName.Nine, Suit.Hearts), new Card(CardName.Nine, Suit.Diamonds),
            new Card(CardName.Ten, Suit.Spades), new Card(CardName.Ten, Suit.Clubs), new Card(CardName.Ten, Suit.Hearts), new Card(CardName.Ten, Suit.Diamonds),
            new Card(CardName.Jack, Suit.Spades), new Card(CardName.Jack, Suit.Clubs), new Card(CardName.Jack, Suit.Hearts), new Card(CardName.Jack, Suit.Diamonds),
            new Card(CardName.Queen, Suit.Spades), new Card(CardName.Queen, Suit.Clubs), new Card(CardName.Queen, Suit.Hearts), new Card(CardName.Queen, Suit.Diamonds),
            new Card(CardName.King, Suit.Spades), new Card(CardName.King, Suit.Clubs), new Card(CardName.King, Suit.Hearts), new Card(CardName.King, Suit.Diamonds),
        };

        private List<Card> communityCards = new List<Card>();

        protected Dealer()
        {
        }

        public static Dealer Instance()
        {
            if (_instance == null)
            {
                _instance = new Dealer();
            }

            return _instance;
        }

        //Deal 2 cards to each player
        public void DealPlayerCards(Player[] players)
        {
            for (int i = 0; i <= 1; i++)
            {
                foreach (Player player in players)
                {
                    Random random = new Random();
                    int index = random.Next(0, 52);
                    while (deck[index].GetIsDealt())
                        index = random.Next(0, 52);

                    deck[index].SetIsDealt();
                    player.AddCard(deck[index]);
                }
            }
        }

        public void DealCommunityCard()
        {
            Random random = new Random();
            int index = random.Next(0, 52);
            while (deck[index].GetIsDealt())
                index = random.Next(0, 52);

            deck[index].SetIsDealt();
            communityCards.Add(deck[index]);
        }

        public void DisplayCommunityCards()
        {
            Console.WriteLine("Community Cards:");
            foreach (Card card in communityCards)
            {
                Console.WriteLine("--- " + card.GetCardName().ToString() + " of " + card.GetSuit().ToString());
            }
        }

    }
}

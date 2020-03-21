using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\t\t\tWelcome to Poker");
            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine("How many players will be playing?");

            int numPlayers;
            string input = Console.ReadLine();
            while (!Int32.TryParse(input, out numPlayers) || numPlayers < 2)
            {
                Console.WriteLine("Please input a number greater than 1.");
                Console.WriteLine("How many players will be playing?");
                input = Console.ReadLine();
            }

            Player[] players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                players[i] = new Player();
            }

            Console.WriteLine("************Dealing Player Cards************");
            Dealer dealer = Dealer.Instance();
            dealer.DealPlayerCards(players);

            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine("Player " + (i + 1).ToString() + " hand:");
                foreach (Card card in players[i].GetHand())
                {
                    Console.WriteLine("--- " + card.GetCardName().ToString() + " of " + card.GetSuit().ToString());
                }
            }

            Console.WriteLine("************Dealing Community Cards************");
            dealer.DealCommunityCard();
            dealer.DealCommunityCard();
            dealer.DealCommunityCard();
            dealer.DisplayCommunityCards();

            Console.ReadLine();
        }
    }
}

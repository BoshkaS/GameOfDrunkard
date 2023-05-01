using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    public class Sharper
    {
        public Deck Deck { get; set; } // deck field

        public Sharper(int amount) // constructor
        {
            Deck = new Deck(amount); // create new deck with specified amount
        }

        public Sharper(Deck deck)
        {
            Deck = deck;
        }

        public Deck GetDeck()
        {
            return Deck;
        }

        public void Shuffle() // method to shuffle the deck
        {
            Random random = new Random(); // create new instance of Random class
            int n = Deck.Cards.Count; // get number of cards in deck

            while (n > 1) // while there are more than 1 cards in deck
            {
                n--; // decrement n
                int k = random.Next(n + 1); // generate random number between 0 and n (inclusive)
                Card card = Deck.Cards[k]; // get card at index k
                Deck.Cards[k] = Deck.Cards[n]; // set card at index k to card at index n
                Deck.Cards[n] = card; // set card at index n to the card previously at index k
            }

            //foreach (Card card in deck.Cards) // for each card in the deck
            //{
            //    Console.WriteLine(card + " "); // output the card to the console
            //}
        }

        public Card DrawCard() // method to draw a card from the deck
        {
            if (Deck.Cards.Count == 0) // if there are no cards in the deck
            {
                throw new InvalidOperationException("The deck is empty."); // throw an exception
            }

            Card card = Deck.Cards[0]; // get the first card in the deck
            Deck.Cards.RemoveAt(0); // remove the card from the deck
            return card; // return the card
        }
        public void DealCards(List<Player> players, Sharper sharp, Deck deck)
        {
            int playersAmount = players.Count;
            int numCards = (int)Math.Floor((double)deck.Amount / (double)playersAmount); // determine the number of cards the players need based on the deck

            foreach (Player player in players)
            {
                for (int i = 0; i < numCards; i++) // deal the appropriate number of cards to the player
                {
                    Card card = sharp.DrawCard(); // draw a card from the deck
                    card.Player = player;
                    player.Cards.Push(card); // add the card to the player's 
                }
            }
        }

        public override string ToString()
        {
            return $"Sharper with {Deck.Amount} cards";
        }
    }

}

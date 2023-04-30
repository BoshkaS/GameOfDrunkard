
namespace GameOfDrunkard
{
    class Program
    {
        static void Main(string[] args)
        {
            //Card card = new Card( Value.king, Suit.hearts);
            //Console.WriteLine(card);
            var cardSharp = new Sharper(36);
            cardSharp.Shuffle();

            Deck deck = cardSharp.GetDeck(); // create a deck with 36 cards

            Player player1 = new Player("Player 1"); // create a player
            Player player2 = new Player("Player 2"); // create a player
            List<Player> container = new List<Player>() { player1, player2 };

            foreach (Player player in container)
            {
                Sharper newCardSharp = new Sharper(36); // create a new instance of Sharper for each player
                newCardSharp.Shuffle();
                Deck newDeck = newCardSharp.GetDeck(); // create a new deck for each player
                newCardSharp.DealCards(container, newCardSharp, newDeck); // deal cards to the players using the new instance of Sharper and the new deck
            }




        }
    }
}
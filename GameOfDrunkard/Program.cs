
namespace GameOfDrunkard
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck(36); // create a deck with 36 cards
            var cardSharp = new Sharper(deck);

            Player player1 = new Player("Bozhena"); // create a player
            Player player2 = new Player("Vika"); // create a player
            Player player3 = new Player("Rostyslav"); // create a player
            List<Player> container = new List<Player>() { player1, player2, player3 };

            Game game = new Game(container, cardSharp);
            game.PlayingGame();
        }
    }
}

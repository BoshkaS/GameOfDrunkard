
namespace GameOfDrunkard
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deck deck = new Deck(36); // create a deck with 36 cards
            //var cardSharp = new Sharper(deck);

            Player player1 = new Player("Bozhena"); // create a player
            Player player2 = new Player("Vika"); // create a player
            Player player3 = new Player("Rostyslav"); // create a player
            List<Player> container = new List<Player>() { player1, player2, player3 };
            Console.Write("Input number of players:");
            int numOfPlayers = int.Parse(Console.ReadLine()); 

            Deck deck;
            if (numOfPlayers >= 2 && numOfPlayers <= 4)
            {
                deck = new Deck(36);
            }
            else if (numOfPlayers >= 5 && numOfPlayers <= 6)
            {
                deck = new Deck(52);
            }
            else
            {
                Console.WriteLine("The number of players must be between 2 and 6!");
                return;
            }

            List<Player> players = new List<Player>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.Write($"Enter player {i + 1} name: ");
                string playerName = Console.ReadLine();
                Player player = new Player(playerName);
                players.Add(player);
            }

            var cardSharp = new Sharper(deck);

            Game game = new Game(container, cardSharp);
            game.PlayingGame();
        }
    }
}

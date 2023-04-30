
namespace GameOfDrunkard
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card( Value.king, Suit.hearts);
            Console.WriteLine(card);
            var cardSharp = new Sharper(52); 
            cardSharp.Shuffle(); 
            
            
            List<string> playerNames = new List<string> { "Player1", "Player2", "Player3"};
            int deckAmount = 52;

            Game game = new Game(playerNames, deckAmount);
            game.Play();

        }
    }
}

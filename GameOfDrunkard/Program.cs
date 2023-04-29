
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

        }
    }
}
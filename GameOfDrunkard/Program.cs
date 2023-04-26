
namespace GameOfDrunkard
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card( Value.king, Suit.hearts);
            Console.WriteLine(card);
        }
    }
}
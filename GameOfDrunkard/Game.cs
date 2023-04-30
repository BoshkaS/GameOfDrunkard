using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrunkard
{
    using System.Collections.Generic;

    public static class StackExtensions
    {
        public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                stack.Push(item);
            }
        }
    }

   
    public class Game
    {
        private readonly List<Player> players;
        private readonly Sharper sharper;
        private readonly Dictionary<Player, Stack<Card>> playerCards;
        private readonly List<Card> tableCards;

        public Game(List<string> playerNames, int deckAmount)
        {
            if (playerNames.Count < 2 || playerNames.Count > 6)
            {
                throw new ArgumentException("The game must have between 2 and 6 players.");
            }

            players = new List<Player>();
            foreach (string name in playerNames)
            {
                players.Add(new Player(name));
            }

            sharper = new Sharper(deckAmount);
            sharper.Shuffle();
           
            
            playerCards = new Dictionary<Player, Stack<Card>>();
            foreach (Player player in players)
            {
                playerCards[player] = new Stack<Card>();
                for (int i = 0; i < deckAmount / playerNames.Count; i++)
                {
                    playerCards[player].Push(sharper.DrawCard());
                }
            }
            
            tableCards = new List<Card>();
        }

       

        public void Play()
        {
            int round = 1;

            while (players.Count > 1)
            {

                Console.WriteLine($"Round {round}:");
                foreach (Player player in players)
                {
                    Console.WriteLine($"{player.Name}: {playerCards[player].Count} cards");
                }

                tableCards.Clear();
                List<Player> activePlayers = new List<Player>(players);
                bool roundWinnerFound = false;
                while (!roundWinnerFound)
                {
                    Dictionary<Player, Card> currentRoundCards = new Dictionary<Player, Card>();
                    foreach (Player player in activePlayers)
                    {
                        if (playerCards[player].Count > 0)
                        {
                            Card card = playerCards[player].Pop();
                            Console.WriteLine($"{player.Name} plays {card}");
                            currentRoundCards[player] = card;
                        }
                    }

                    if (currentRoundCards.Count > 0)
                    {
                        Card highestCard = currentRoundCards.Values.Max();

                        List<Player> roundWinners = currentRoundCards.Where(kv => kv.Value.Equals(highestCard))
                                                                     .Select(kv => kv.Key)
                                                                     .ToList();

                        if (roundWinners.Count == 1)
                        {
                            Player roundWinner = roundWinners[0];
                            Console.WriteLine($"{roundWinner.Name} wins the round");

                            foreach (Card card in currentRoundCards.Values.OrderByDescending(c => c.Value))
                            {
                                roundWinner.cards.Push(card);
                            }

                            if (playerCards[roundWinner].Count == 0)
                            {
                                players.Remove(roundWinner);
                            }

                            roundWinnerFound = true;
                        }
                        else
                        {
                            Console.WriteLine("War!");

                            for (int i = 0; i < 3; i++)
                            {
                                foreach (Player player in roundWinners)
                                {
                                    if (playerCards[player].Count > 0)
                                    {
                                        Card card = playerCards[player].Pop();
                                        Console.WriteLine($"{player.Name} plays {card}");
                                        currentRoundCards[player] = card;
                                    }
                                }
                            }

                            highestCard = currentRoundCards.Values.Max();
                            roundWinners = currentRoundCards.Where(kv => kv.Value.Equals(highestCard))
                                                             .Select(kv => kv.Key)
                                                             .ToList();

                            if (roundWinners.Count == 1)
                            {
                                Player roundWinner = roundWinners[0];
                                Console.WriteLine($"{roundWinner.Name} wins the war and takes the change");

                                foreach (Card card in currentRoundCards.Values.OrderByDescending(c => c.Value))
                                {
                                    roundWinner.cards.Push(card);
                                }

                                if (playerCards[roundWinner].Count == 0)
                                {
                                    players.Remove(roundWinner);
                                }

                                roundWinnerFound = true;
                            }
                            else
                            {
                                Console.WriteLine("Another war!");

                                
                                Play();
                                return;
                            }
                        }

                        if (players.Count == 1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("All players have run out of cards, the game ends in a tie!");
                        return;
                    }
                }

               
                round++;
            }

            Console.WriteLine($"{players[0].Name} wins the game!");
        }
    }
}
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
        private readonly List<Player> Players;
        private readonly Sharper Sharper;
        //private readonly Dictionary<Player, Stack<Card>> playerCards;
        //private readonly List<Card> tableCards;

        public Game(List<Player> playerNames, Sharper sharper)
        {
            if (playerNames.Count < 2 || playerNames.Count > 6)
            {
                throw new ArgumentException("The game must have between 2 and 6 players.");
            }

            Players = new List<Player>(playerNames);
            

            Sharper = sharper;
            Sharper.Shuffle();
           
            //playerCards = new Dictionary<Player, Stack<Card>>();

            Sharper.DealCards(Players, Sharper, Sharper.Deck);

            //foreach (Player player in Players)
            //{
            //    playerCards[player] = new Stack<Card>();
            //    for (int i = 0; i < Sharper.Deck.Amount / playerNames.Count; i++)
            //    {
            //        playerCards[player].Push(sharper.DrawCard());
            //    }
            //}
            foreach (var player in Players)
            {
                Console.WriteLine(player);
            }
            //tableCards = new List<Card>();
        }

       

        //public void Play()
        //{
        //    int round = 1;

        //    while (Players.Count > 1)
        //    {

        //        Console.WriteLine($"Round {round}:");
        //        foreach (Player player in Players)
        //        {
        //            Console.WriteLine($"{player.Name}: {player.Cards.Count} cards");
        //        }

        //        tableCards.Clear();
        //        List<Player> activePlayers = new List<Player>(Players);
        //        bool roundWinnerFound = false;
        //        while (!roundWinnerFound)
        //        {
        //            Dictionary<Player, Card> currentRoundCards = new Dictionary<Player, Card>();
        //            foreach (Player player in activePlayers)
        //            {
        //                if (player.Cards.Count > 0)
        //                {
        //                    Card card = player.Cards.Pop();
        //                    Console.WriteLine($"{player.Name} plays {card}");
        //                    currentRoundCards[player] = card;
        //                }
        //            }

        //            if (currentRoundCards.Count > 0)
        //            {
        //                Card highestCard = currentRoundCards.Values.Max();

        //                List<Player> roundWinners = currentRoundCards.Where(kv => kv.Value.Equals(highestCard))
        //                                                             .Select(kv => kv.Key)
        //                                                             .ToList();

        //                if (roundWinners.Count == 1)
        //                {
        //                    Player roundWinner = roundWinners[0];
        //                    Console.WriteLine($"{roundWinner.Name} wins the round");

        //                    foreach (Card card in currentRoundCards.Values.OrderByDescending(c => c.Value))
        //                    {
        //                        roundWinner.Cards.Push(card);
        //                    }

        //                    if (playerCards[roundWinner].Count == 0)
        //                    {
        //                        Players.Remove(roundWinner);
        //                    }

        //                    roundWinnerFound = true;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("War!");

        //                    for (int i = 0; i < 3; i++)
        //                    {
        //                        foreach (Player player in roundWinners)
        //                        {
        //                            if (playerCards[player].Count > 0)
        //                            {
        //                                Card card = playerCards[player].Pop();
        //                                Console.WriteLine($"{player.Name} plays {card}");
        //                                currentRoundCards[player] = card;
        //                            }
        //                        }
        //                    }

        //                    highestCard = currentRoundCards.Values.Max();
        //                    roundWinners = currentRoundCards.Where(kv => kv.Value.Equals(highestCard))
        //                                                     .Select(kv => kv.Key)
        //                                                     .ToList();

        //                    if (roundWinners.Count == 1)
        //                    {
        //                        Player roundWinner = roundWinners[0];
        //                        Console.WriteLine($"{roundWinner.Name} wins the war and takes the change");

        //                        foreach (Card card in currentRoundCards.Values.OrderByDescending(c => c.Value))
        //                        {
        //                            roundWinner.Cards.Push(card);
        //                        }

        //                        if (playerCards[roundWinner].Count == 0)
        //                        {
        //                            Players.Remove(roundWinner);
        //                        }

        //                        roundWinnerFound = true;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Another war!");

                                
        //                        Play();
        //                        return;
        //                    }
        //                }

        //                if (Players.Count == 1)
        //                {
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("All players have run out of cards, the game ends in a tie!");
        //                return;
        //            }
        //        }

               
        //        round++;
        //    }

        //    Console.WriteLine($"{Players[0].Name} wins the game!");
        //}
        public void PlayingGame()
        {
            int round = 1;
            while (true)
            {
                //if (round == 30) break;
                
                List<Player> tempPlayers = Players.Where(player => player.Cards.Count > 0).ToList();
                List<List<Card>> cardsOnTable = new List<List<Card>>();
                if (tempPlayers.Count == 1)
                {
                    Console.WriteLine($"The winner is {tempPlayers[0].Name}");
                    break;
                }
                Console.WriteLine($"\nRound: {round}\n");

                while (tempPlayers.Count > 1)
                {
                    
                    List<Card> subRound = new List<Card>();
                    
                    for (int i = 0; i < tempPlayers.Count; ++i)
                    {
                        try
                        {
                            if (cardsOnTable.Count > 0)
                            {
                                cardsOnTable[^1].Add(tempPlayers[i].Cards.Pop());
                                cardsOnTable[^1].Add(tempPlayers[i].Cards.Pop());
                            }
                            Card card = tempPlayers[i].Cards.Pop();
                            subRound.Add(card);
                            Console.WriteLine($"{tempPlayers[i].Name} has {tempPlayers[i].Cards.Count} cards and he put '{subRound[i]}'");
                        }
                        catch {
                        
                        }
                        
                    }
                    cardsOnTable.Add(subRound);

                    int maxCard = subRound.Select(x => (int)x.Value).Max();
                    if (subRound.Count(x => (int)x.Value == 14) > 0)
                    {
                        if (subRound.Count(x => (int)x.Value == 2) > 0)
                        {
                            maxCard = 2;
                        }
                        if (subRound.Count(x => (int)x.Value == 6) > 0 && Sharper.Deck.Amount == 36)
                        {
                            maxCard = 6;
                        }
                    }
                    List<Card> maxCards = subRound.Where(x => (int)x.Value == maxCard).ToList();
                    for (int i = 0; i < tempPlayers.Count; ++i)
                    {
                        if (maxCards.Where(x => x.Player != tempPlayers[i]).Count() == maxCards.Count())
                        {
                            tempPlayers[i] = null;
                        }
                    }
                    tempPlayers = tempPlayers.Where(x => x != null).ToList();
                    int amount = 0;
                    for (int i = 0; i < cardsOnTable.Count(); ++i)
                    {
                        amount += cardsOnTable[i].Count();
                    }
                    Console.WriteLine($"Amount of cards on table is {amount}");
                }

                Stack<Card> tempStack = new Stack<Card>();
                for (int i = cardsOnTable.Count - 1; i >= 0; --i)
                {
                    for(int j = cardsOnTable[i].Count - 1; j >= 0; --j)
                    {
                        cardsOnTable[i][j].Player = tempPlayers[0];
                        tempStack.Push(cardsOnTable[i][j]);
                    }
                }
                List<Card> listOfCards = tempPlayers[0].Cards.ToList();
                for (int i = listOfCards.Count - 1; i >= 0; --i)
                {
                    tempStack.Push(listOfCards[i]);
                }
                tempPlayers[0].Cards = tempStack;
                round++;
                
            }
        }
    }
}
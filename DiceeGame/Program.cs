using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Logic;

namespace DiceeGame {
    class Program {
        static void Main(string[] args) {

            int numOfPlayer = 2;

            do {
                Console.Write("Enter number of players: ");
            } while (!int.TryParse(Console.ReadLine(), out numOfPlayer));

            DiceGame game = new DiceGame(2);

            for (int i = 0; i < numOfPlayer; i++) {
                game.AddPlayer(new Player("Player"+(i+1)));
            }

            Console.WriteLine();

            PlayGame(game);
            Console.ReadKey();
        }

        public static void PlayGame(DiceGame game) {
            game.StartGame();
            Random random = new Random();
            while (!game.IsGameOver) {
                Console.WriteLine("Turn: " + (game.Turn+1));
                game.PlayTurn(random);
                PrintPlayerTurnInfo(game);
                if (game.IsGameOver) {
                    break;
                }
                game.SetNextPlayer();
            }

            GenerateGameResult(game);
        }

        public static void PrintPlayerTurnInfo(DiceGame game) {
            Player activePlayer = game.ActivePlayer;

            Console.WriteLine("Active Player: " + activePlayer.Name);
            Console.Write("Dices: ");
            foreach (Dice dice in game.Dices) {
                Console.Write(dice.Face + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Score: " + activePlayer.Score);
            Console.WriteLine("Turn result: " + activePlayer.History[game.Turn]);
            Console.WriteLine();
        }

        public static void GenerateGameResult(DiceGame game) {
            Player winner = game.TheWinner();

            Console.WriteLine("WINNER: " + winner.Name);
            for (int i = 0; i < winner.History.Count; i++) {
                Console.WriteLine("Turn " + (i+1) + ": " + winner.History[i]);
            }
        }
    }
}

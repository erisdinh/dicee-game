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

            DiceGame game = new DiceGame(2);

            for (int i = 0; i < numOfPlayer; i++) {
                game.AddPlayer(new Player("Player"+(i+1)));
            }

            PlayGame(game);
            Console.ReadKey();
        }

        public static void PlayGame(DiceGame game) {
            game.StartGame();

            while (!game.IsGameOver) {
                Console.WriteLine("Turn: " + (game.Turn+1));
                game.PlayTurn();
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
            for (int i = 0; i < game.Dices.Count; i++) {
                Console.Write(game.Dices[i].Face + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Score: " + activePlayer.Score);
            Console.WriteLine("Turn result: " + activePlayer.History[game.Turn]);
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

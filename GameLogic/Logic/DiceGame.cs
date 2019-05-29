using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Logic {
    public class DiceGame {
        private List<Player> _players;
        private List<Dice> _dices;
        private Player _activePlayer;
        private bool _isGameOver;
        private int _playerIndex;
        private int _numOfDice;
        private int _turn;

        public DiceGame(int numOfDice) {
            _players = new List<Player>();
            _dices = new List<Dice>();
            _numOfDice = numOfDice;
            _isGameOver = true;
        }

        public List<Player> Players {
            get { return _players; }
            set { _players = value; }
        }

        public List<Dice> Dices {
            get { return _dices; }
        }

        public Player ActivePlayer {
            get { return _activePlayer; }
            private set { _activePlayer = value; }
        }

        public int Turn {
            get { return _turn; }
        }

        public bool IsGameOver {
            get {
                int jackpot = 0;
                for (int i = 0; i < _activePlayer.History.Count; i++) {
                    if (_activePlayer.History[i] == RollResult.JACKPOT) {
                        jackpot++;
                    }
                }
                if (jackpot >= 2 || _turn > 5) {
                    _isGameOver = true;
                } else {
                    _isGameOver = false;
                }
                return _isGameOver;
            }
        }

        public void AddPlayer(Player player) {
            if (_isGameOver != true) {
                throw new Exception("The game has been started. You cannot add new player.");
            } else {
                _players.Add(player);
            }

        }

        public void StartGame() {
            _playerIndex = 0;
            if (_players.Count < 2) {
                throw new Exception("Please add a new player.");
            } else {
                _isGameOver = false;
                _activePlayer = _players[_playerIndex];
            }
        }

        public void PlayTurn() {
            _dices = new List<Dice>();
            RollDice();
            ComputeTurnResult();
            UpdatePlayerStat();
        }

        public void RollDice() {
            for (int i = 0; i < _numOfDice; i++) {
                Dice dice = new Dice();
                dice.Roll();
                Console.WriteLine("Dices in RollDice: " + dice.Face);
                _dices.Add(dice);
                Console.WriteLine("Dice in RollDice " + i + ": " + _dices[i].Face);
            }
        }

        public void ComputeTurnResult() {
            bool isSameFace = false;
            int score;
            for (int i = 0; i < (_dices.Count - 1); i++) {
                Console.WriteLine("Dices in ComputeTurnResult: " + _dices[i].Face + "   " + _dices[i+1].Face);
                if (_dices[i].Face == _dices[i+1].Face) {
                    isSameFace = true;
                } else {
                    isSameFace = false;
                    break;
                }
            }

            if (isSameFace == true) {
                if (_dices[0].Face == _dices[0].Max) {
                    _activePlayer.History.Add(RollResult.JACKPOT);
                    score = _dices.Count * _dices[0].Max * 10;

                } else {
                    _activePlayer.History.Add(RollResult.WIN);
                    score = _dices.Count * _dices[0].Face * 5;
                }
            } else {
                _activePlayer.History.Add(RollResult.LOSE);
                score = 0;
            }
            _activePlayer.Score = score;
        }

        public void UpdatePlayerStat() {
            _players[_playerIndex] = _activePlayer;
        }

        public void SetNextPlayer() {
            if (_playerIndex < (_players.Count - 1)) {
                _playerIndex++;
            } else {
                _turn++;
                _playerIndex = 0;
            }
             _activePlayer = _players[_playerIndex];
        }

        public Player TheWinner() {
            Player winnerPlayer;
            winnerPlayer = _players[0];
            for (int i = 0; i < (_players.Count - 1); i++) {
                if (_players[i].Score < _players[i + 1].Score) {
                    winnerPlayer = _players[i + 1];
                }
            }
            return winnerPlayer;
        }
    }
}

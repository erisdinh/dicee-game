using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Logic {

    /// <summary>
    /// DiceGame object
    /// </summary>
    public class DiceGame {
        private List<Player> _players;
        private List<Dice> _dices;
        private Player _activePlayer;
        private bool _isGameOver;
        private int _playerIndex;
        private int _numOfDice;
        private int _turn;

        /// <summary>
        /// Constructor of the Dice Game
        /// </summary>
        /// <param name="numOfDice">Serves as number of dices used in the game</param>
        public DiceGame(int numOfDice) {
            _players = new List<Player>();
            _numOfDice = numOfDice;
            _isGameOver = true;
        }

        /// <summary>
        /// List of players of the game
        /// </summary>
        public List<Player> Players {
            get { return _players; }
            set { _players = value; }
        }

        /// <summary>
        /// List of dices for each turn
        /// </summary>
        public List<Dice> Dices {
            get { return _dices; }
            set { _dices = value; }
        }

        /// <summary>
        /// Current active player who is playing
        /// </summary>
        public Player ActivePlayer {
            get { return _activePlayer; }
            private set { _activePlayer = value; }
        }

        /// <summary>
        /// Index of the current turn
        /// </summary>
        public int Turn {
            get { return _turn; }
        }

        /// <summary>
        /// Check whether the Dice Gmae is over
        /// </summary>
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

        /// <summary>
        /// Add new player to the Dice Name
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player) {
            if (_isGameOver != true) {
                throw new Exception("The game has been started. You cannot add new player.");
            } else {
                _players.Add(player);
            }

        }

        /// <summary>
        /// Start the Dice Game
        /// </summary>
        public void StartGame() {
            _playerIndex = 0;
            if (_players.Count < 2) {
                throw new Exception("Please add a new player.");
            } else {
                _isGameOver = false;
                _activePlayer = _players[_playerIndex];
            }
        }

        /// <summary>
        /// Play each player turn
        /// </summary>
        /// <param name="random">Serves as an random object for rolling dices</param>
        public void PlayTurn(Random random) {
            RollDice(random);
            ComputeTurnResult();
            UpdatePlayerStat();
        }

        /// <summary>
        /// Roll the dices
        /// </summary>
        /// <param name="random">Serves as an random object for rolling dices</param>
        public void RollDice(Random random) {
            _dices = new List<Dice>();
            for (int i = 0; i < _numOfDice; i++) {
                Dice dice = new Dice();
                dice.Roll(random);
                _dices.Add(dice);
            }
        }

        /// <summary>
        /// Compute the result and score of player turn
        /// </summary>
        public void ComputeTurnResult() {
            bool isSameFace = false;
            int score;
            for (int i = 0; i < (_dices.Count-1); i++) {
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
            _activePlayer.Score += score;
        }

        /// <summary>
        /// Update status of players
        /// </summary>
        public void UpdatePlayerStat() {
            _players[_playerIndex] = _activePlayer;
        }

        /// <summary>
        /// Set the next player in turn
        /// </summary>
        public void SetNextPlayer() {
            if (_playerIndex < (_players.Count - 1)) {
                _playerIndex++;
            } else {
                _playerIndex = 0;
                _turn++;
            }
             _activePlayer = _players[_playerIndex];
        }

        /// <summary>
        /// Get the winner of the Dice Game
        /// </summary>
        /// <returns></returns>
        public Player TheWinner() {
            Player winnerPlayer = null;
            int maxScore = 0;
            for (int i = 0; i < (_players.Count); i++) {
                if (_players[i].Score > maxScore) {
                    maxScore = _players[i].Score;
                    winnerPlayer = _players[i];
                }
            }
            return winnerPlayer;
        }
    }
}

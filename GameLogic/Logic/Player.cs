using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Logic {

    /// <summary>
    /// Player object of the game
    /// </summary>
    public class Player {
        private string _name;
        private int _score;
        private List<RollResult> _history;
        
        /// <summary>
        /// Constructor of Player
        /// </summary>
        /// <param name="name">Serves as name of the player</param>
        public Player(string name) {
            Name = name;
            _history = new List<RollResult>();
        }

        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Cummulative score of the player
        /// </summary>
        public int Score {
            get { return _score; }
            set { _score = value; }
        }

        /// <summary>
        /// Result list of player's turns
        /// </summary>
        public List<RollResult> History {
            get { return _history; }
            set { _history = value; }
        }
    }
}

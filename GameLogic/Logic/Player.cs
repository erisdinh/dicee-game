using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Logic {
    public class Player {
        private string _name;
        private int _score;
        private List<RollResult> _history;

        public Player(string name) {
            Name = name;
            _history = new List<RollResult>();
        }

        public Player() {
            _history = new List<RollResult>();
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public int Score {
            get { return _score; }
            set { _score = value; }
        }

        public List<RollResult> History {
            get { return _history; }
            set { _history = value; }
        }
    }
}

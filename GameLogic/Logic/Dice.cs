using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Logic {
    public class Dice {
        private int _max;
        private int _face;

        public Dice() {
            _max = 6;
        }

        public int Max {
            get { return _max; }
            set { _max = value; }
        }

        public int Face {
            get { return _face; }
        }

        public void Roll() {
            Random random = new Random();
            _face = random.Next(1, _max + 1);
        }
    }
}

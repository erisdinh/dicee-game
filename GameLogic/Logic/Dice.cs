using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Logic {

    /// <summary>
    /// Dice object
    /// </summary>
    public class Dice {
        private int _max;
        private int _face;

        public Dice() {
            _max = 6;
        }

        /// <summary>
        /// Max value (face) of the dice
        /// </summary>
        public int Max {
            get { return _max; }
        }

        /// <summary>
        /// The face that is generated when the dice is rolled
        /// </summary>
        public int Face {
            get { return _face; }
            set { _face = value; }
        }

        /// <summary>
        /// Roll the dice from 1 to its max value
        /// </summary>
        /// <param name="random">Serves as random object to roll the dice</param>
        public void Roll(Random random) {
            _face = random.Next(1, (_max + 1));
        }
    }
}

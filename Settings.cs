using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheat.Base
{
    public class Settings
    {
        public _ESP ESP = new _ESP();
        public class _ESP {
            public bool Player;
            public bool Item;
            public bool Extract;
            public bool Container;
        }
        public bool freecam;
        public bool fc_fwd;
        public bool fc_bwd;
        public bool fc_left;
        public bool fc_right;
        public bool fc_up;
        public bool fc_down;

    }
}

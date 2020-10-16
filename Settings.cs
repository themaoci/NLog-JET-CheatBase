using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog_CheatBase
{
    public class Settings
    {
        public _ESP ESP = new _ESP();
        public _Distances Distances = new _Distances();
        public class _ESP {
            public bool Corpse;
            public bool Extract;
            public bool Item;
            public bool Player;
            public bool Throwable;
            public bool Container;
        }
        public class _Distances {
            public int Corpse = 500;
            public int Extract = 2000;
            public int Item = 500;
            public int Player = 500;
            public int Throwable = 200;
            public int Container = 500;
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

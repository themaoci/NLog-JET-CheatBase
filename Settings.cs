using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog_Example_CheatBase
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

    }
}

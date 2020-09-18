using EFT;
using NLog_Example_CheatBase.Tools;
using NLog_Example_CheatBase.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_Example_CheatBase.Features
{
    class PlayerESP
    {
        private static List<ESPBase<Player>> playerList;
        private static List<ESPBase<Player>> _TplayerList;
        private Player tpo; // temporal player object;
        private ESPBase<Player> _tpo; // temporal player helper object;
        public void Update() 
        {
            // we gonna use enumerators cause they leave less trash behind
            var e = Instance.gameWorld.PlayersList.GetEnumerator();
            _TplayerList.Clear();
            while (e.MoveNext()) 
            {
                tpo = e.Current;
                _tpo = new ESPBase<Player>(tpo);
                _TplayerList.Add(_tpo);
            }
            playerList = _TplayerList;
        }
        public void Draw() 
        {
            var e = playerList.GetEnumerator();
            while (e.MoveNext()) {
                var curr = e.Current;
                DrawSystem.Dot.Draw(curr.Position_2D, Color.yellow, 2f);
            }

        }
    }
}

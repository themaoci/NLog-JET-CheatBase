using EFT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Cheat.Base;
using NLog_CheatBase.Tools.Structures;
using NLog_CheatBase.Tools;

namespace NLog_CheatBase.Features
{
    class PlayerESP
    {
        private ScreenCalc screen_f = new ScreenCalc();
        private static List<PlayerStruct> playerList = new List<PlayerStruct>();
        private static List<PlayerStruct> _TplayerList = new List<PlayerStruct>();
        private Player tpo; // temporal player object;
        private PlayerStruct _tpo; // temporal player struct object;
        public void Update() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (Instance.gameWorld.PlayersList.Count <= 0) return;
            // we gonna use enumerators cause they leave less trash behind
            //var e = Instance.gameWorld.PlayersList.GetEnumerator();
            _TplayerList.Clear();

            // maybe this will speedup after i will make a proper data collection
            Parallel.For(0, Instance.gameWorld.PlayersList.Count, Instance.maxThreadOptions, i =>
            {
                tpo = Instance.gameWorld.PlayersList[i];
                _tpo = new PlayerStruct(tpo);
                _TplayerList.Add(_tpo);
            });

            playerList = _TplayerList;
        }
        private Vector2 vec2tt = new Vector2(100f, 15f);//yes this is lazy but working so will leave it here
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = Color.red }, fontSize = 12 };
        private string _text;
        private Vector2 _size;
        public void Draw() 
        {
            if (playerList == null) return;
            if (playerList.Count <= 0) return;

            var e = playerList.GetEnumerator();
            while (e.MoveNext())
            {
                var curr = e.Current;
                if (!screen_f.IsOnScreenStrict(curr.Position)) continue;

                // DrawSystem.Dot.Draw(curr.HeadPosition, Color.yellow, 2f); // if you need a dot for head position ;)
                _text = $"{curr.ItemInHands}";
                _size = DrawSystem.Calc.TextSize(_text);
                DrawSystem.Special.DrawText(_text, curr.HeadPosition.x - _size.x/2, curr.HeadPosition.y - 40f - _size.y, vec2tt, guiStyle, Color.red);

                _text = $"{curr.Distance} {curr.HealthPercent}";
                _size = DrawSystem.Calc.TextSize(_text);
                DrawSystem.Special.DrawText(_text, curr.HeadPosition.x - _size.x/2, curr.HeadPosition.y - 40f - _size.y - _size.y, vec2tt, guiStyle, Color.red);
            }
        }
    }
}

using EFT;
using Cheat.Base.Tools;
using Cheat.Base.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat.Base.Features
{
    class PlayerESP
    {
        // such a stupid mistake ...
        private static List<PlayerStruct> playerList = new List<PlayerStruct>();
        private static List<PlayerStruct> _TplayerList = new List<PlayerStruct>();
        private Player tpo; // temporal player object;
        private PlayerStruct _tpo; // temporal player helper object;
        public void Update() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (Instance.gameWorld.PlayersList.Count <= 0) return;
            // we gonna use enumerators cause they leave less trash behind
            var e = Instance.gameWorld.PlayersList.GetEnumerator();
            _TplayerList.Clear();
            while (e.MoveNext()) 
            {
                tpo = e.Current;
                _tpo = new PlayerStruct(tpo);
                _TplayerList.Add(_tpo);
            }
            playerList = _TplayerList;
        }
        private Vector2 vec2tt = new Vector2(100f, 15f);
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = Color.red }, fontSize = 12 };
        private string _text;
        private Vector2 _size;
        public void Draw() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (playerList == null) return;
            if (playerList.Count <= 0) return;

            var e = playerList.GetEnumerator();
            while (e.MoveNext())
            {
                var curr = e.Current;
                //DrawSystem.Dot.Draw(curr.Position_onScreen, Color.yellow, 2f);
                _text = $"{curr.ItemInHands}";
                _size = GUI.skin.GetStyle(_text).CalcSize(GuiText(_text));
                DrawSystem.Special.DrawText(_text, curr.Position_onScreen.x - _size.x/2, curr.Position_onScreen.y - 40f - _size.y, vec2tt, guiStyle, Color.red);

                _text = $"{curr.Distance} {curr.HealthPercent}";
                _size = GUI.skin.GetStyle(_text).CalcSize(GuiText(_text));
                DrawSystem.Special.DrawText(_text, curr.Position_onScreen.x - _size.x/2, curr.Position_onScreen.y - 40f - _size.y - _size.y, vec2tt, guiStyle, Color.red);
            }
        }
        private static GUIContent tempGuiContent = new GUIContent();
        public static GUIContent GuiText(string text)
        {
            tempGuiContent.text = text;
            return tempGuiContent;
        }
    }
}

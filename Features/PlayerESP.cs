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
        private static List<ESPBase<Player>> playerList = new List<ESPBase<Player>>();
        private static List<ESPBase<Player>> _TplayerList = new List<ESPBase<Player>>();
        private Player tpo; // temporal player object;
        private ESPBase<Player> _tpo; // temporal player helper object;
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
                _tpo = new ESPBase<Player>(tpo);
                _TplayerList.Add(_tpo);
            }
            playerList = _TplayerList;
        }
        private Vector2 vec2tt = new Vector2(100f, 15f);
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = Color.red }, fontSize = 12 };
        public void Draw() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (playerList == null) return;
            if (playerList.Count <= 0) return;

            var e = playerList.GetEnumerator();
            while (e.MoveNext())
            {
                var curr = e.Current;
                DrawSystem.Dot.Draw(curr.Position_2D, Color.yellow, 2f);
                string text = $"{curr.Name}";
                float width = GUI.skin.GetStyle(text).CalcSize(GuiText(text)).x;
                DrawSystem.Special.DrawText(text, curr.Position_2D.x - width/2, curr.Position_2D.y - 20f, vec2tt, guiStyle, Color.red);
                text = $"{curr.Distance}m";
                width = GUI.skin.GetStyle(text).CalcSize(GuiText(text)).x;
                DrawSystem.Special.DrawText(text, curr.Position_2D.x - width / 2, curr.Position_2D.y, vec2tt, guiStyle, Color.red);
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

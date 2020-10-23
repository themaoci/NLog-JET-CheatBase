using EFT.Interactive;
using NLog_CheatBase.Tools;
using NLog_CheatBase.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_CheatBase.Features
{
    class ExfilESP
    {
        private ScreenCalc screen_f = new ScreenCalc();
        private List<ExfiltrationStruct> exfilList = new List<ExfiltrationStruct>();
        private List<ExfiltrationStruct> _exfilList = new List<ExfiltrationStruct>();
        private List<ScavExfiltrationPoint> _exfilsScav;
        private List<ExfiltrationPoint> _exfilsPmc;
        public void Update()
        {
            _exfilsScav = Instance.gameWorld.ScavExfiltrationPoints;
            _exfilsPmc = Instance.gameWorld.ExfiltrationPoints;
            _exfilList.Clear();
            if (_exfilsScav.Count > 0)
            {
                Parallel.For(0, _exfilsScav.Count, Instance.maxThreadOptions, i =>
                {
                    _exfilList.Add(new ExfiltrationStruct(_exfilsScav[i]));
                });
            }
            if (_exfilsPmc.Count > 0)
            {
                Parallel.For(0, _exfilsPmc.Count, Instance.maxThreadOptions, i =>
                {
                    _exfilList.Add(new ExfiltrationStruct(_exfilsPmc[i]));
                });
            }
            exfilList = _exfilList;
            
        }
        private string _text;
        private Vector2 _size;
        private Vector2 vec2tt = new Vector2(100f, 15f);//yes this is lazy but working so will leave it here
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = new Color(1f, 1f, 1f, .8f) }, fontSize = 12 };
        public void Draw()
        {
            if (exfilList == null) return;
            if (exfilList.Count <= 0) return;

            var e = exfilList.GetEnumerator();
            while (e.MoveNext())
            {
                var curr = e.Current;
                if (!screen_f.IsOnScreenStrict(curr.Position)) continue;

                //DrawSystem.Dot.Draw(curr.HeadPosition, Color.yellow, 2f);
                _text = $"{curr.Name}";
                _size = DrawSystem.Calc.TextSize(_text);
                DrawSystem.Special.DrawText(_text, curr.Position.x - _size.x / 2, curr.Position.y - 40f - _size.y, vec2tt, guiStyle);

                _text = $"{curr.Distance}";
                _size = DrawSystem.Calc.TextSize(_text);
                DrawSystem.Special.DrawText(_text, curr.Position.x - _size.x / 2, curr.Position.y - 40f - _size.y - _size.y, vec2tt, guiStyle);
            }
        }
    }
}

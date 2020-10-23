using Cheat.Base;
using NLog_CheatBase.Tools;
using NLog_CheatBase.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

#pragma warning disable 649  // disable not assigned variable

namespace NLog_CheatBase.Features
{
    class ThrowableESP
    {
        private ScreenCalc screen_f = new ScreenCalc();
        private List<ThrowableStruct> throwableList = new List<ThrowableStruct>();
        private List<ThrowableStruct> _throwableList = new List<ThrowableStruct>();
        private List<Throwable>.Enumerator _throwableEnum;
        private List<Throwable> _throwableTempList;
        public void Update()
        {
            _throwableEnum = Instance.gameWorld.Grenades;
            _throwableList.Clear();
            _throwableTempList.Clear();
            while (_throwableEnum.MoveNext()) {
                _throwableTempList.Add(_throwableEnum.Current);
            }
            Parallel.For(0, _throwableTempList.Count, Instance.maxThreadOptions, i =>
            {
                _throwableList.Add(new ThrowableStruct(_throwableTempList[i]));
            });
            throwableList = _throwableList;

        }
        private string _text;
        private Vector2 _size;
        private Vector2 vec2tt = new Vector2(100f, 15f);//yes this is lazy but working so will leave it here
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = new Color(1f, 1f, 1f, .8f) }, fontSize = 12 };
        public void Draw()
        {
            if (throwableList == null) return;
            if (throwableList.Count <= 0) return;

            var e = throwableList.GetEnumerator();
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

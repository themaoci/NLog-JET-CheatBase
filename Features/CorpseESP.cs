using Cheat.Base;
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
    class CorpseESP
    {
        //public static Type Corpse = new Corpse().GetType();
        //public static Type ObserverCorpse = new ObservedCorpse().GetType();
        private ScreenCalc screen_f = new ScreenCalc();
        private List<CorpseStruct> corpseList = new List<CorpseStruct>();
        private List<CorpseStruct> _corpseList = new List<CorpseStruct>();
        private List<LootItem> _LootItemList;
        public void Update() {
            lock (Instance._LootDataLocker)
            {
                _LootItemList = Instance.gameWorld.LootList;
            }
            if (_LootItemList == null) return;
            _corpseList.Clear();
            Parallel.For(0, _LootItemList.Count, Instance.maxThreadOptions, i =>
            {
                var corpse = _LootItemList[i];
                if (corpse is Corpse/* || e is ObservedCorpse*/)//observer is online only
                    _corpseList.Add(new CorpseStruct(corpse));
            });
            corpseList = _corpseList;
        }
        private string _text;
        private Vector2 _size;
        private Vector2 vec2tt = new Vector2(100f, 15f);//yes this is lazy but working so will leave it here
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = new Color(1f, 1f, 1f, .8f) }, fontSize = 12 };
        public void Draw()
        {
            if (corpseList == null) return;
            if (corpseList.Count <= 0) return;

            var e = corpseList.GetEnumerator();
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

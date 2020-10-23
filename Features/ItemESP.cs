using Cheat.Base;
using EFT.Interactive;
using NLog_CheatBase.Tools;
using NLog_CheatBase.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

#pragma warning disable 169 // disable not assigned variable

namespace NLog_CheatBase.Features
{
    class ItemESP
    {
        private ScreenCalc screen_f = new ScreenCalc();
        private List<ItemStruct> itemList = new List<ItemStruct>();
        private List<ItemStruct> _itemList = new List<ItemStruct>();
        private List<LootItem>.Enumerator _enumLootItemList;
        private List<LootItem> _LootItemList;
        public void Update()
        {
            lock (Instance._LootDataLocker)
            {
                _LootItemList = Instance.gameWorld.LootList;
            }
            if (_LootItemList == null) return;
            _itemList.Clear();
            Parallel.For(0, _LootItemList.Count, Instance.maxThreadOptions, i =>
            {
                var item = _LootItemList[i];
                if (item is LootItem/* || item is ObservedLootItem*/)// observed is online only
                    _itemList.Add(new ItemStruct(item));
            });
            itemList = _itemList;
        }
        private string _text;
        private Vector2 _size;
        private Vector2 vec2tt = new Vector2(100f, 15f);//yes this is lazy but working so will leave it here
        private GUIStyle guiStyle = new GUIStyle() { normal = { textColor = new Color(1f, 1f, 1f, .8f) }, fontSize = 12 };
        public void Draw() {
            if (itemList == null) return;
            if (itemList.Count <= 0) return;

            var e = itemList.GetEnumerator();
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

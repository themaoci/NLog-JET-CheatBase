using Cheat.Base;
using EFT.Interactive;
using NLog_Example_CheatBase.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_Example_CheatBase.Features
{
    class ItemESP
    {
        private List<ItemStruct> itemList = new List<ItemStruct>();
        private List<ItemStruct> _itemList = new List<ItemStruct>();
        private List<LootItem>.Enumerator _enumLootItemList;
        private List<LootItem> _LootItemList;

        public void Update()
        {
            _enumLootItemList = Instance.gameWorld.LootItems;
            _itemList.Clear();
            _LootItemList.Clear();
            
            while (_enumLootItemList.MoveNext())
            { // this shouldnt be that slow - somehow we need to convert this fast from enumerator to list...
                _LootItemList.Add(_enumLootItemList.Current);
            }
            // parallel threading cause this oen below should be intensive for game loop cause of alot of items
            Parallel.ForEach(_LootItemList, item => {
                if(item is LootItem/* || item is ObservedLootItem*/)// observer is online only
                    _itemList.Add(new ItemStruct(item));
            });
            itemList = _itemList;
        }
        public void Draw() { }
    }
}

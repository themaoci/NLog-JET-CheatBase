using Cheat.Base;
using Cheat.Base.Tools;
using EFT.Interactive;
using NLog_Example_CheatBase.Tools.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog_Example_CheatBase.Features
{
    class CorpseESP
    {
        //public static Type Corpse = new Corpse().GetType();
        //public static Type ObserverCorpse = new ObservedCorpse().GetType();
        private List<CorpseStruct> corpseList = new List<CorpseStruct>();
        private List<CorpseStruct> _corpseList = new List<CorpseStruct>();
        private List<LootItem>.Enumerator _LootItemList;
        public void Update() {
            _LootItemList = Instance.gameWorld.LootItems;
            _corpseList.Clear();
            // this shouldnt be that slow
            while (_LootItemList.MoveNext())
            {
                var e = _LootItemList.Current;
                if (e is Corpse/* || e is ObservedCorpse*/)//observer is online only
                    _corpseList.Add(new CorpseStruct(e));
            }
            corpseList = _corpseList;
        }
        public void Draw() { }
    }
}

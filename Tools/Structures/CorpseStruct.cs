using EFT.Interactive;
using UnityEngine;


namespace NLog_CheatBase.Tools.Structures
{
    class CorpseStruct : ESPBase
    {
        private LootItem _corpse;
        public CorpseStruct(LootItem corpse) 
        {
            _corpse = corpse;
            _objectName = "Corpse";// _corpse.Item.ShortName.Localized();
            _positionBase = LocalGameWorld.W2S(_corpse.transform.position);
            _distance = (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _corpse.transform.position);
        }
    }
}

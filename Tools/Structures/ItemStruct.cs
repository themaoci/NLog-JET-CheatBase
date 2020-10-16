using EFT.Interactive;
using UnityEngine;

namespace NLog_CheatBase.Tools.Structures
{
    class ItemStruct : ESPBase
    {
        private LootItem _lootItem;
        public ItemStruct(LootItem item) {
            _lootItem = item;
            _objectName = _lootItem.Item.ShortName.Localized();
            _positionBase = LocalGameWorld.W2S(_lootItem.transform.position);
            _distance = (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _lootItem.transform.position);
        }
    }
}

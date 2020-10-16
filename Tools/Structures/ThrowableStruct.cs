using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_CheatBase.Tools.Structures
{
    class ThrowableStruct : ESPBase
    {
        Throwable _throwable;
        public ThrowableStruct(Throwable throwable) {
            _throwable = throwable;
            _objectName = _GenerateObjectName(_throwable.name);// _corpse.Item.ShortName.Localized();
            _positionBase = LocalGameWorld.W2S(_throwable.transform.position);
            _distance = (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _throwable.transform.position);
        }

        private string _GenerateObjectName(string objectUnityName) {
            switch (objectUnityName)
            {
                case "weapon_rgd5_world(Clone)":
                    return "RGD-5";
                case "weapon_grenade_f1_world(Clone)":
                    return "F1";
                case "weapon_rgd2_world(Clone)":
                    return "Smoke";
                case "weapon_m67_world(Clone)":
                    return "M67";
                case "weapon_zarya_world(Clone)":
                    return "Zarya";
                default:
                    return objectUnityName.Replace("weapon_", "").Replace("_world(Clone)", "").Replace("grenade_", "");
            }
        }
    }
}

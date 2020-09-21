using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheat.Base.Tools.Structures;
using Cheat.Base.Tools;
using Cheat.Base.Tools.Player;
using System;

namespace Cheat.Base.Tools.Structures
{
    class PlayerStruct
    {
        private EFT.Player _playerData;
        public PlayerStruct(EFT.Player player)
        {
            _playerData = player;
        }

        private int _getHealth
        {
            get
            {
                return (int)_playerData.HealthController.GetBodyPartHealth(EBodyPart.Common).Current;
            }
        }
        private int _getHealthMax
        {
            get
            {
                return (int)_playerData.HealthController.GetBodyPartHealth(EBodyPart.Common).Maximum;
            }
        }
        private int _GetDistance
        {
            get
            {
                return (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _playerData.Transform.position);
            }
        }
        private void _drawBoneConnection(Vector3 bone_1, Vector3 bone_2)
        {
            //later add settings for colors and thiccness
            DrawSystem.Bone.Draw(bone_1, bone_2, Color.white, 1f);
        }

        public string Health
        {
            get
            {
                return $"{_getHealth} HP";
            }
        }
        public string HealthPercent {
            get 
            {
                return $"{Math.Round(_getHealth / _getHealthMax * 100.0, 0)}% HP";
            }
        }
        public string Distance
        {
            get
            {
                return $"{_GetDistance}m";
            }
        }
        public string ItemInHands
        {
            get 
            {
                return $"{_playerData.HandsController.Item.ShortName.Localized()}";
            }
        }
        public Vector3 DrawBones()
        {
            if (_playerData == null) return Vector3.zero;
            List<Vector3> boneList = Bones.GetPlayerBonePositions_inW2S(_playerData); // 0-12
            // Lame bone connection drawing :>
            _drawBoneConnection(boneList[1], boneList[2]);   // 1- Neck, 2- Pelvis
            _drawBoneConnection(boneList[5], boneList[6]);   // 5- L Upperarm, 6- L Forearm
            _drawBoneConnection(boneList[10], boneList[11]); // 10- R Upperarm, 11- R Forearm
            _drawBoneConnection(boneList[6], boneList[7]);   // 6- L Forearm, 7- L Palm
            _drawBoneConnection(boneList[11], boneList[12]); // 11- R Forearm, 12- R Palm
            _drawBoneConnection(boneList[10], boneList[5]);  // 10- R Upperarm, 5- L Upperarm
            _drawBoneConnection(boneList[3], boneList[2]);   // 3- L Calf, 2- Pelvis
            _drawBoneConnection(boneList[8], boneList[2]);   // 8- R Calf, 2- Pelvis
            _drawBoneConnection(boneList[3], boneList[4]);   // 3- L Calf, L Foot
            _drawBoneConnection(boneList[8], boneList[9]);   // 8- R Calf, R Foot
            return Vector3.zero;
        }
        public Vector3 Position_onScreen
        {
            get
            {
                Vector3 _pos = LocalGameWorld.W2S(_playerData.PlayerBody.PlayerBones.Head.position);
                _pos.y = Screen.height - _pos.y;
                return _pos;
            }
        }
        public string Name
        {
            get
            {
                return _playerData.Profile.Info.Nickname;
            }
        }
    }
}

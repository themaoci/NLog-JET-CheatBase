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
    class PlayerStruct : ESPBase
    {
        private EFT.Player _playerData;
        public PlayerStruct(EFT.Player player)
        {
            // this struct should be multithreaded, for the sake of performance and less loop lag
            _playerData = player;
            _itemInHands = _playerData.HandsController.Item.ShortName.Localized();
            _getHealth = (int)_playerData.HealthController.GetBodyPartHealth(EBodyPart.Common).Current;
            _getHealthMax = (int)_playerData.HealthController.GetBodyPartHealth(EBodyPart.Common).Maximum;
            _distance = (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _playerData.Transform.position);
            _bonePositions = Bones.GetPlayerBonePositions_inW2S(_playerData);
            _getHealthProcent = (int)Math.Round(_getHealth / _getHealthMax * 100.0, 0);
            _positionHead = LocalGameWorld.W2S(_playerData.PlayerBody.PlayerBones.Head.position);
            _positionHead.y = Screen.height - _positionHead.y;
            _positionBase = LocalGameWorld.W2S(_playerData.Transform.position);
            _positionBase.y = Screen.height - _positionBase.y;
            _objectName = _playerData.Profile.Info.Nickname; // for now lets stay like this ;)
        }
        //private string _objectName;
        //private int _distance;
        //private Vector3 _positionBase;
        private string _itemInHands;
        private int _getHealth;
        private int _getHealthMax;
        private int _getHealthProcent;
        private List<Vector3> _bonePositions;
        private Vector3 _positionHead;

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
                return $"{_getHealthProcent}% HP";
            }
        }
        public string ItemInHands
        {
            get 
            {
                return $"{_itemInHands}";
            }
        }
        public Vector3 DrawBones()
        {
            // Lame bone connection drawing :>
            _drawBoneConnection(_bonePositions[1], _bonePositions[2]);   // 1- Neck, 2- Pelvis
            _drawBoneConnection(_bonePositions[5], _bonePositions[6]);   // 5- L Upperarm, 6- L Forearm
            _drawBoneConnection(_bonePositions[10], _bonePositions[11]); // 10- R Upperarm, 11- R Forearm
            _drawBoneConnection(_bonePositions[6], _bonePositions[7]);   // 6- L Forearm, 7- L Palm
            _drawBoneConnection(_bonePositions[11], _bonePositions[12]); // 11- R Forearm, 12- R Palm
            _drawBoneConnection(_bonePositions[10], _bonePositions[5]);  // 10- R Upperarm, 5- L Upperarm
            _drawBoneConnection(_bonePositions[3], _bonePositions[2]);   // 3- L Calf, 2- Pelvis
            _drawBoneConnection(_bonePositions[8], _bonePositions[2]);   // 8- R Calf, 2- Pelvis
            _drawBoneConnection(_bonePositions[3], _bonePositions[4]);   // 3- L Calf, 4- L Foot
            _drawBoneConnection(_bonePositions[8], _bonePositions[9]);   // 8- R Calf, 9- R Foot
            return Vector3.zero;
        }
        public Vector3 HeadPosition
        {
            get
            {
                return _positionHead;
            }
        }
    }
}

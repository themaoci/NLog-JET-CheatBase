using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using NLog_CheatBase.Tools.Player;

namespace NLog_CheatBase.Tools.Structures
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

        public Vector3 HeadPosition
        {
            get
            {
                return _positionHead;
            }
        }
    }
}

﻿using EFT;
using EFT.Interactive;
using System;
using UnityEngine;

namespace Cheat.Base.Tools.Structures
{
    public enum TypeOf { 
        Player,
        Item,
        Container,
        Extract,
        Other
    }
    public class ESPBase<T>
    {

        public ESPBase(T type) 
        {
            if (type is Player)
            {
                _typeOf = TypeOf.Player;
                _playerData = type as Player;
            }
            if (type is LootItem)
            {
                _typeOf = TypeOf.Item;
                _itemData = type as LootItem;
            }
        }

        private TypeOf _typeOf;
        //private GameObject gameObject;

        private Player _playerData;
        private LootItem _itemData;

        private int _GetDistance {
            get
            {
                switch (_typeOf)
                {
                    case TypeOf.Player: 
                        return (int)Vector3.Distance(
                            LocalGameWorld.MainCamera.transform.position,
                            _playerData.Transform.position);
                    case TypeOf.Item: 
                        return (int)Vector3.Distance(
                            LocalGameWorld.MainCamera.transform.position,
                            _itemData.transform.position);
                }
                return 0;
            }
        }
        public int Distance {
            get 
            {
                return _GetDistance;
            }
        }
        public Vector3 Position_2D {
            get 
            {
                Vector3 _pos = Vector3.zero;
                switch (_typeOf)
                {
                    case TypeOf.Player:
                        _pos = LocalGameWorld.W2S(_playerData.Transform.position);
                        break;
                    case TypeOf.Item:
                        _pos = LocalGameWorld.W2S(_itemData.transform.position);
                        break;
                }
                _pos.y = Screen.height - _pos.y;
                return _pos;
            }
        }
        public string Name {
            get 
            {
                try {
                    switch (_typeOf) 
                    {
                        case TypeOf.Player:
                            if (_playerData.Profile != null)
                                return _playerData.Profile.Info.Nickname;
                            else return "fucklol";
                        case TypeOf.Item: 
                            return _itemData.Name.Localized();
                    }
                }
                catch (NullReferenceException e)
                {
                    Debug.LogError(e);
                }
                return "~";
            }
        }
        public string TextLine1 = "";
        public string TextLine2 = "";
        public string TextLine3 = "";
        public string TextLine4 = "";
    }
}

using EFT;
using EFT.Interactive;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NLog_CheatBase.Tools.Structures
{

    public class ESPBase
    {
        internal Vector3 _positionBase;
        internal string _objectName;
        internal int _distance;
        public Vector3 Position
        {
            get
            {
                return _positionBase;
            }
        }
        public string Name
        {
            get
            {
                return _objectName;
            }
        }
        public string Distance
        {
            get
            {
                return $"{_distance}m";
            }
        }

    }
}

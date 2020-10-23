using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_CheatBase.Tools
{
    class ScreenCalc
    {
        /// <summary>
        /// Calculates Vector3 from world up to screen space - getting camera from LocalGameWorld.MainCamera
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Vector3</returns>
        public Vector3 WorldToScreen(Vector3 vector) {
            return LocalGameWorld.MainCamera.WorldToScreenPoint(vector);
        }
        /// <summary>
        /// Is on screen Strict - which blocks everything off the screen
        /// </summary>
        /// <param name="Vector3"></param>
        /// <returns>Boolean</returns>
        public bool IsOnScreenStrict(Vector3 V)
        {
            if (V.x > 0.01f && V.y > 0.01f && V.x < Screen.width && V.y < Screen.height && V.z > 0.01f)
                return true;
            return false;
        }
        /// <summary>
        /// Is on screen Vertical Strict - which hides elements too much above ar below (not hiding elements on the left or right side) - very helpfull for snap lines
        /// </summary>
        /// <param name="Vector3"></param>
        /// <returns>Boolean</returns>
        public bool IsOnScreenVertical(Vector3 V)
        {
            if (V.y > 0.01f && V.y < Screen.height && V.z > 0.01f)
                return true;
            return false;
        }
    }
}

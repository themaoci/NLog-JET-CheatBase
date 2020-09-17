using UnityEngine;

namespace NLog_Example_CheatBase.Tools.Structures
{
    public class ESPBase
    {
        public string name;
        public Vector3 position;
        public Transform transform;
        public GameObject gameObject;
        public int Distance {
            get 
            {
                return (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, gameObject.transform.position);
            }
        }
        public string TextLine1 = "";
        public string TextLine2 = "";
        public string TextLine3 = "";
        public string TextLine4 = "";
    }
}

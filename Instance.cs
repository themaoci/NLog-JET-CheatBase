using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_Example_CheatBase
{
    public class Instance : MonoBehaviour
    {
        public static string watermark = "[MAO]";
        private void Start()
        {
            Debug.LogError("Instance Started.");
            gameObject.AddComponent<Menu>(); // adding menu component
            ///do things after starting module
        }
        private void Update() 
        {

        }
    }
}

using NLog_Example_CheatBase.Features;
using NLog_Example_CheatBase.Tools;
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
        //global scope access
        public static string watermark = "[MAO]";
        public static LocalGameWorld gameWorld = new LocalGameWorld();
        public static Settings settings = new Settings();
        //local scope access
        private PlayerESP playerESP = new PlayerESP();
        private void Start()
        {
            Debug.LogError("Instance Started.");
            gameObject.AddComponent<Menu>(); // adding menu component

            ///do things after starting module
        }
        private void Update() 
        {
            if(settings.ESP.Player)
                playerESP.Update();
        }
    }
}

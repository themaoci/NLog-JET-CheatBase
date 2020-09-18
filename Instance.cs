using Cheat.Base.Features;
using Cheat.Base.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat.Base
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
        private void OnGUI() 
        {
            if (settings.ESP.Player)
                playerESP.Draw();
        }
    }
}

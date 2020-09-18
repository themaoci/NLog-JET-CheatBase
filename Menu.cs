using Cheat.Base.Tools;
using NLog_Example_CheatBase.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cheat.Base
{
    class Menu : MonoBehaviour
    {
        FreeCam fC = new FreeCam();
        private void Awake() {
            Debug.LogError(Instance.watermark + " Loaded: Menu");
        }
        Rect _menu = new Rect(10f,10f,220f,200f);
        void Update() 
        {
            if (Instance.settings.freecam)
            {
                fC.Enable();
            }
            else 
            {
                fC.Disable();
            }
        }
        private void OnGUI() {
            //drawing happends here
            _menu = GUILayout.Window(0, _menu, MenuDrawer, SetGuiContent("--- Menu ---"));
        }
        private static void MenuDrawer(int id) {
            switch (id) {
                case 0:
                    GUILayout.Width(150f);
                    DrawSystem.Menu.Label("-= BaseMenu =-", true);
                    DrawSystem.Menu.Label("Loaded: " + Instance.gameWorld.gameWorldLoaded);
                    DrawSystem.Menu.Label("Scene: " + SceneManager.GetActiveScene().name);
                    if(Instance.gameWorld.PlayersList != null)
                        DrawSystem.Menu.Label("PlayerCount: " + (Instance.gameWorld.PlayersList.Count).ToString());
                    DrawSystem.Menu.Checkbox("Player ESP", ref Instance.settings.ESP.Player);
                    break;
                default: break;
            }
        }
        private static GUIContent _GuiContent = new GUIContent();
        public static GUIContent SetGuiContent(string text)
        {
            _GuiContent.text = text;
            return _GuiContent;
        }
    }
}

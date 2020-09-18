using NLog_Example_CheatBase.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NLog_Example_CheatBase
{
    class Menu : MonoBehaviour
    {
        private void Awake() {
            Debug.LogError(Instance.watermark + " Loaded: Menu");
        }
        Rect _menu;
        private void OnGUI() {
            //drawing happends here
            _menu = GUILayout.Window(0, _menu, MenuDrawer, SetGuiContent("Menu"));
        }
        private static void MenuDrawer(int id) {
            switch (id) {
                case 0: 
                    DrawSystem.Menu.Label("-= BaseMenu =-", true);
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

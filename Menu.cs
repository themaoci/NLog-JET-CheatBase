using NLog_CheatBase.Features;
using NLog_CheatBase.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NLog_CheatBase
{
    class Menu : MonoBehaviour
    {
        private void Awake() {
            Debug.LogError(Instance.watermark + " Loaded: Menu");
        }
        Rect _menu = new Rect(10f, 10f, 220f, 200f);
        Rect _LocalPpos = new Rect(10f, 5f, 220f, 20f);

        #region Temporal Private Variables
        private FreeCam fC = new FreeCam();
        private static float _cameraSpeed = 1f;
        private static float _moveSpeed = 1f;
        private static bool _lockPlayer = false;
        private bool _displayMenu = false;
        private bool _drawPosition = false;
        #endregion

        void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Insert)) {
                _displayMenu = !_displayMenu;
            }
            //Below GameWorldLoaded Sensitive Data
            if (!Instance.gameWorld.gameWorldLoaded) return;

            if (Input.GetKeyDown(KeyCode.F10))
            {
                fC.TeleportPlayerToCamera();
            }
            if (Instance.settings.freecam)
            {
                fC.Enable();
            }
            else 
            {
                fC.Disable();
            }
            if (fC.Enabled)
            {
                
                fC.CameraSpeed = _cameraSpeed;
                fC.MoveSpeed = _moveSpeed;
                fC.LockPlayer = _lockPlayer;
                fC.LockPlayerToCamera();
                fC.Move();
                fC.MouseMove();
            }
        }
        private void OnGUI() {
            //drawing happends here
            if (_displayMenu)
            {
                GUI_MainMenu();
            }
            if (_drawPosition) 
            {
                if(Instance.gameWorld.LocalPlayer != null)
                    GUI.Label(_LocalPpos, Instance.gameWorld.LocalPlayer.Transform.position.ToString());
            }
        }
        void GUI_MainMenu() {
            _menu = GUILayout.Window(0, _menu, MenuDrawer, SetGuiContent(Instance.watermark + " Menu"));
        }
        private void MenuDrawer(int id) {
            switch (id) {
                case 0:
                    GUILayout.Width(150f);
                    //DrawSystem.Menu.Label("-= Menu =-", true);
                    //DrawSystem.Menu.Label("Loaded: " + Instance.gameWorld.gameWorldLoaded);
                    DrawSystem.Menu.Label("Scene: " + SceneManager.GetActiveScene().name);
                    if(Instance.gameWorld.PlayersList != null)
                        DrawSystem.Menu.Label("PlayerCount: " + (Instance.gameWorld.PlayersList.Count).ToString()); 
                    DrawSystem.Menu.Checkbox("Show LocalPl. Pos.", ref _drawPosition);
                    DrawSystem.Menu.Label("ESP",true);
                    DrawSystem.Menu.Checkbox("Player", ref Instance.settings.ESP.Player);
                    DrawSystem.Menu.Checkbox("Corpse", ref Instance.settings.ESP.Corpse);
                    DrawSystem.Menu.Checkbox("Exfil", ref Instance.settings.ESP.Extract);
                    DrawSystem.Menu.Checkbox("Item", ref Instance.settings.ESP.Item);
                    DrawSystem.Menu.Checkbox("Throwable", ref Instance.settings.ESP.Throwable);
                    DrawSystem.Menu.Label("- - -", true);
                    DrawSystem.Menu.Checkbox("FreeCamera", ref Instance.settings.freecam);
                    DrawSystem.Menu.Checkbox("LockPlayerToCamera", ref _lockPlayer);
                    DrawSystem.Menu.Label("Player2Camera: F10");
                    DrawSystem.Menu.Slider.Horizontal.Float(ref _cameraSpeed, 1f, 100f, "Camera Speed", true);
                    DrawSystem.Menu.Slider.Horizontal.Float(ref _moveSpeed, 1f, 100f, "Move Speed", true);
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

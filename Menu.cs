using Cheat.Base.Tools;
using Cheat.Base.Features;
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
        private bool _displayMenu = false;
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
            if (fC.Enabled)
            {
                fC.CameraSpeed = _cameraSpeed;
                fC.MoveSpeed = _moveSpeed;
                fC.LockPlayer = _lockPlayer;
                fC.LockPlayerToCamera();
                fC.Move();
                fC.MouseMove();
            }
            if (Input.GetKeyDown(KeyCode.F10)) 
            {
                fC.TeleportPlayerToCamera();
            }
            if (Input.GetKeyDown(KeyCode.Insert)) {
                _displayMenu = !_displayMenu;
            }
        }
        private void OnGUI() {
            //drawing happends here
            _menu = GUILayout.Window(0, _menu, MenuDrawer, SetGuiContent("Menu"));
        }
        private static float _cameraSpeed = 1f;
        private static float _moveSpeed = 1f;
        private static bool _lockPlayer = false;
        private void MenuDrawer(int id) {
            switch (id) {
                case 0:
                    GUILayout.Width(150f);
                    //DrawSystem.Menu.Label("-= Menu =-", true);
                    //DrawSystem.Menu.Label("Loaded: " + Instance.gameWorld.gameWorldLoaded);
                    DrawSystem.Menu.Label("Scene: " + SceneManager.GetActiveScene().name);
                    if(Instance.gameWorld.PlayersList != null)
                        DrawSystem.Menu.Label("PlayerCount: " + (Instance.gameWorld.PlayersList.Count).ToString());
                    DrawSystem.Menu.Checkbox("Player ESP", ref Instance.settings.ESP.Player);
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

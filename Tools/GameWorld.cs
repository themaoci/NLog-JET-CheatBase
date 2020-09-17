using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFT;
using EFT.Interactive;
using UnityEngine;

namespace NLog_Example_CheatBase.Tools
{
    class LocalGameWorld
    {
        static Camera _mainCamera;
        GameWorld _gameWorld = null;
        bool _gameWorldLoaded = false;

        public static Camera MainCamera {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
        public bool gameWorldLoaded {
            get 
            {
                return _gameWorldLoaded;
            }
        }
        public GameWorld gameWorld {
            get 
            {
                _gameWorld = Comfort.Common.Singleton<GameWorld>.Instance; // possibility of throwing errors null object
                _gameWorldLoaded = _gameWorld != null;
                return _gameWorld;
            }
        }
        public List<Player> PlayersList {
            get 
            {
                if (_gameWorldLoaded)
                    return gameWorld.RegisteredPlayers;
                return null;
            }
        }
        public List<LootItem>.Enumerator LootItems
        {
            get
            {
                return gameWorld.LootItems.GetValuesEnumerator().GetEnumerator();
            }
        }
        public List<Throwable>.Enumerator Grenades
        {
            get
            {
                return gameWorld.Grenades.GetValuesEnumerator().GetEnumerator();
            }
        }
        public List<ExfiltrationPoint> ExfiltrationPoints
        {
            get
            {
                return gameWorld.ExfiltrationController.ExfiltrationPoints.ToList();
            }
        }
        public List<ScavExfiltrationPoint> ScavExfiltrationPoints
        {
            get
            {
                return gameWorld.ExfiltrationController.ScavExfiltrationPoints.ToList();
            }
        }
        public List<WorldInteractiveObject> WorldInteractiveObject { 
            get 
            {
                return LocationScene.GetAllObjects<WorldInteractiveObject>(false).Cast<WorldInteractiveObject>().ToList();
            }
        }

    }
}

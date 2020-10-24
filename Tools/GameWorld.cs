using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFT;
using EFT.Interactive;
using UnityEngine;

namespace NLog_CheatBase.Tools
{
    public class LocalGameWorld
    {
        static Camera _mainCamera;
        public static Camera BackupMainCamera;
        public static Camera MainCamera {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
        // propably will be disbanded //
        public static Vector3 W2S(Vector3 vec) 
        { // i dont like long names...
            return MainCamera.WorldToScreenPoint(vec);
        }
        public bool gameWorldLoaded {
            get 
            {
                return gameWorld != null;
            }
        }
        public GameWorld gameWorld {
            get 
            {
                if(Comfort.Common.Singleton<EFT.GameWorld>.Instantiated)
                    return Comfort.Common.Singleton<EFT.GameWorld>.Instance;
                return null;
            }
        }
        public List<LootItem> LootList;
        public List<EFT.Player> PlayersList {
            get 
            {
                if (gameWorldLoaded)
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
        /* 
        this list is fucking retarded you need to use this retarded Enumerator which cannot be transfered to list to improve performance ...
        i will need to make new thread jsut to transform it from Enumerator into List<LootItem> so i will be able to use it in Parallel loops
        public GClass365<int, LootItem> LootItems_Base
        {
            get
            {
                return gameWorld.LootItems;
            }
        }*/
        public List<Throwable>.Enumerator Grenades
        {
            get
            {
                return gameWorld.Grenades.GetValuesEnumerator().GetEnumerator();
            }
        }
        private EFT.Player _localplayer;
        public EFT.Player LocalPlayer {
            get {
                if (!gameWorldLoaded)
                {
                    _localplayer = null;
                    return null;
                }
                // this variable need to be override after going to new scene/map
                if (_localplayer == null)
                {
                    List<EFT.Player> tmpList = PlayersList;
                    tmpList = tmpList.OrderBy(tempPlayer => Vector3.Distance(MainCamera.transform.position, tempPlayer.Transform.position)).ToList();
                    _localplayer = tmpList.FirstOrDefault();
                }
                return _localplayer;
            }
            set { _localplayer = value; }
        }
        public GClass439<int, Throwable> GrenadesBase
        {
            get
            {
                return gameWorld.Grenades;
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

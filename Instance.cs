using Cheat.Base.Features;
using Cheat.Base.Tools;
using EFT.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat.Base
{
    public class Instance : MonoBehaviour
    {
        //global scope access
        public static ParallelOptions maxThreadOptions = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };
        public static string watermark = "[MAO]";
        public static LocalGameWorld gameWorld = new LocalGameWorld();
        public static Settings settings = new Settings();
        //local scope access
        private PlayerESP playerESP = new PlayerESP();
        public static Thread updateLootList_Thread;
        private void Start()
        {
            Debug.LogError(watermark + " Instance Started.");
            gameObject.AddComponent<Menu>(); // adding menu component
            //start thread for Loot Conversion
            updateLootList_Thread = new Thread(new ThreadStart(UpdateLootToBeLessRetarded));
            updateLootList_Thread.Start();
            ///do things after starting module
        }
        #region Thread #1 - LootItem List Conversion
        private void UpdateLootToBeLessRetarded() {
            List<LootItem> _tmpList = new List<LootItem>();
            while (updateLootList_Thread.ThreadState == ThreadState.Running) {
                if (!gameWorld.gameWorldLoaded) {
                    Thread.Sleep(1000); continue; 
                }
                List<LootItem>.Enumerator _LootItemList = Instance.gameWorld.LootItems;
                _tmpList.Clear();
                while (_LootItemList.MoveNext())
                {
                    if(_LootItemList.Current != null)
                        _tmpList.Add(_LootItemList.Current);
                }
                gameWorld.LootList = _tmpList;
                Thread.Sleep(500); // delay execution by 500 ms cause it not need to be updated that much
            }
        }
        #endregion

        private void Update() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (settings.ESP.Player)
                playerESP.Update();
        }
        private void OnGUI() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (settings.ESP.Player)
                playerESP.Draw();
        }
    }
}

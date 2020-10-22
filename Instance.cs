using EFT.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog_CheatBase.Features;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using NLog_CheatBase.Tools;

namespace NLog_CheatBase
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
        private CorpseESP corpseESP = new CorpseESP();
        private ExfilESP exfilESP = new ExfilESP();
        private ItemESP itemESP = new ItemESP();
        private ThrowableESP throwableESP = new ThrowableESP();
        public static readonly object _LootDataLocker = new object();
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
            // errors happend to be in here at the start of match
            List<LootItem> _tmpList = new List<LootItem>();
            while (updateLootList_Thread.ThreadState == ThreadState.Running) {
                if (!gameWorld.gameWorldLoaded) {
                    Thread.Sleep(1000); continue; 
                }
                lock (_LootDataLocker)
                {
                    List<LootItem>.Enumerator _LootItemList = Instance.gameWorld.LootItems;
                    if (_tmpList.Count != 0)
                        _tmpList.Clear();
                    if (_LootItemList.Current == null) continue;

                    while (_LootItemList.MoveNext())
                    {
                        if (_LootItemList.Current != null)
                            _tmpList.Add(_LootItemList.Current);
                    }
                    gameWorld.LootList = _tmpList;
                }
                Thread.Sleep(500); // delay execution by 500 ms cause it not need to be updated that much
            }
        }
        #endregion

        private void Update() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;

            if (settings.ESP.Player)
                playerESP.Update();

            if (settings.ESP.Corpse)
                corpseESP.Update();

            if (settings.ESP.Throwable)
                throwableESP.Update();

            if (settings.ESP.Extract)
                exfilESP.Update();

            if (settings.ESP.Item)
                itemESP.Update();
        }
        private void OnGUI() 
        {
            if (!Instance.gameWorld.gameWorldLoaded) return;
            if (settings.ESP.Player)
                playerESP.Draw();

            if (settings.ESP.Player)
                playerESP.Draw();

            if (settings.ESP.Corpse)
                corpseESP.Draw();

            if (settings.ESP.Throwable)
                throwableESP.Draw();

            if (settings.ESP.Extract)
                exfilESP.Draw();

            if (settings.ESP.Item)
                itemESP.Draw();
        }
    }
}

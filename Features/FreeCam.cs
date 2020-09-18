using Cheat.Base.Tools;
using UnityEngine;


namespace NLog_Example_CheatBase.Features
{
    class FreeCam
    {
        LocalGameWorld gameWorld = new LocalGameWorld();
        bool enabled;
        public void Enable() 
        {
            if (!enabled)
            {
                LocalGameWorld.BackupMainCamera = LocalGameWorld.MainCamera;
                enabled = true;
            }
        }
        public void Disable()
        {
            if (enabled)
            {
                LocalGameWorld.MainCamera.transform.localPosition = LocalGameWorld.BackupMainCamera.transform.localPosition;
                LocalGameWorld.MainCamera.transform.localEulerAngles = LocalGameWorld.BackupMainCamera.transform.localEulerAngles;
                enabled = false;
            }
        }

    }
}

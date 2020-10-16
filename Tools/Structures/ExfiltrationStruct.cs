using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using EFT;
using EFT.Interactive;

namespace NLog_CheatBase.Tools.Structures
{
    class ExfiltrationStruct : ESPBase
    {
        private ScavExfiltrationPoint _scavExfil;
        private ExfiltrationPoint _pmcExfil;
        private EExfiltrationStatus _status;
        public ExfiltrationStruct(ExfiltrationPoint exfil)
        {
            _pmcExfil = exfil;
            _objectName = _pmcExfil.Settings.Name.Localized();
            _positionBase = LocalGameWorld.W2S(_pmcExfil.transform.position);
            _distance = (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _pmcExfil.transform.position);
            _status = _pmcExfil.Status;
        }
        public ExfiltrationStruct(ScavExfiltrationPoint exfil)
        {
            _scavExfil = exfil;
            _objectName = _scavExfil.Settings.Name.Localized();
            _positionBase = LocalGameWorld.W2S(_scavExfil.transform.position);
            _distance = (int)Vector3.Distance(LocalGameWorld.MainCamera.transform.position, _scavExfil.transform.position);
            _status = _scavExfil.Status;
        }
        public string Status() {
            switch (_status)
            {
                case EExfiltrationStatus.AwaitsManualActivation:
                    return "Manual";
                case EExfiltrationStatus.Countdown:
                    return "Timer";
                case EExfiltrationStatus.NotPresent:
                    return "Closed";
                case EExfiltrationStatus.Pending:
                    return "Pending";
                case EExfiltrationStatus.RegularMode:
                    return "Open";
                case EExfiltrationStatus.UncompleteRequirements:
                    return "Req.";
                default:
                    return "";
            }
        }
    }
}

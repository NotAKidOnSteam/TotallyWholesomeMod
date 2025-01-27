﻿using System;
using System.Linq;
using ABI_RC.Core.Savior;
using MelonLoader;
using TotallyWholesome.Managers.Lead;
using TotallyWholesome.Notification;
using WholesomeLoader;
using Yggdrasil.Logging;

namespace TotallyWholesome.Managers.ModCompatibility
{
    public class ModCompatibility : ITWManager
    {

        public int Priority() => 0;
        public string ManagerName() => nameof(ModCompatibility);

        private bool _lastVRState;

        public void Setup()
        {
            if (Environment.CommandLine.Contains("--TWUIXMode") && UIXAdapter.IsUIXAvailable())
            {
                Con.Msg("TotallyWholesome is currently using UIX mode!");
            }

            if (NotificationAPIAdapter.IsNotifAPIAvailable())
            {
                Con.Msg("Detected [Information Redacted]'s NotificationAPI, it will be used in place of the CVR hud notifications!");
            }

            if (VRCPlatesAdapter.IsVRCPlatesEnabled())
            {
                Con.Msg("Detected FS's VRCPlates, TW Status will be adjusted to work with them.");
                VRCPlatesAdapter.SetupVRCPlateCompat();
            }
        }

        private void OnLocalAvatarReady()
        {
            if(_lastVRState == MetaPort.Instance.isUsingVr) return;

            Con.Msg("Detected VR mode switch, reconfiguring TW...");
            _lastVRState = MetaPort.Instance.isUsingVr;
            
            NotificationSystem.VRModeSwitched();
            LeadManager.Instance.SetupTWRaycaster();
        }

        public void LateSetup()
        {
            _lastVRState = MetaPort.Instance.isUsingVr;
            Patches.OnLocalAvatarReady += OnLocalAvatarReady;
        }
    }
}

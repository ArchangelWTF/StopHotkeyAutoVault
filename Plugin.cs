﻿using BepInEx;

namespace StopHotkeyAutoVault
{
    [BepInPlugin("com.archangelwtf.stophotkeyautovault", "Stop Hotkey Auto-Vault", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
			new PatchAutovault().Enable();
		}
    }
}
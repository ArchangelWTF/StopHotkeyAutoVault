using Comfort.Common;
using EFT;
using SPT.Reflection.Patching;
using System.Reflection;
using static GClass960;

namespace StopHotkeyAutoVault
{
	public class PatchAutovault : ModulePatch
	{
		protected override MethodBase GetTargetMethod() => typeof(Player).GetMethod(nameof(Player.Vaulting), BindingFlags.Public | BindingFlags.Instance);

		[PatchPrefix]
		private static bool PatchPrefix(ref float ____vaultingTiming, Player __instance)
		{
			if (Singleton<SharedGameSettingsClass>.Instance.Game.Settings.AutoVaultingMode == EAutoVaultingUseMode.Automatic)
			{
				//Run original method, this will leave the player to autovault over everything until the end of the raid if he switches it back mid-raid
				return true;
			}

			____vaultingTiming = 0f;
			__instance.method_14();

			//Skip original method
			return false;
		}
	}
}

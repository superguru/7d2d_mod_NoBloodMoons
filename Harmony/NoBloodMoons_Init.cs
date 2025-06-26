using System;
using System.Reflection;

using HarmonyLib;
using HarmonyLib.Tools;
using NoBloodMoons.Scripts.Utils;

namespace NoBloodMoons
{
    public sealed class NoBloodMoons : IModApi
    {
        private static NoBloodMoons _context;

        internal static Mod ModInstance;

        public void InitMod(Mod modInstance)
        {
            if (modInstance == null)
            {
                LogUtil.Error("Mod instance is null in InitMod.");
                throw new ArgumentNullException(nameof(modInstance));
            }

            _context = this;
            ModInstance = modInstance;

            LogUtil.Info("Initializing NoBloodMoons mod...");

            var harmonyId = "NoBloodMoons.Mod";
            var harmony = new Harmony(harmonyId);

#if DEBUG
            HarmonyFileLog.Enabled = true;
            LogUtil.DebugLog("Harmony file logging enabled.");
#endif
            try
            {
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                LogUtil.Info("Harmony patches applied successfully.");
            }
            catch (Exception ex)
            {
                LogUtil.Error("Failed to apply Harmony patches.", ex);
                throw;
            }
        }
    }
}

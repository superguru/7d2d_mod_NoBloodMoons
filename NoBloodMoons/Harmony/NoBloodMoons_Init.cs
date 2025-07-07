using System;
using System.Reflection;

using HarmonyLib;
using NoBloodMoons.Scripts.Utils;

#if DEBUG
using HarmonyLib.Tools;
#endif

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

            LogUtil.Info("Initializing No Blood Moons mod...");

            var harmonyId = "NoBloodMoons.Mod";
            var harmony = new Harmony(harmonyId);

#if DEBUG
            HarmonyFileLog.Enabled = true;
            LogUtil.DebugLog("Harmony file logging enabled.");
#endif
            try
            {
                var executing_assembly = Assembly.GetExecutingAssembly();
                harmony.PatchAll(executing_assembly);
                LogUtil.Info($"Harmony patches applied successfully for {executing_assembly.FullName}");
            }
            catch (Exception ex)
            {
                LogUtil.Error("Failed to apply Harmony patches.", ex);
                throw;
            }
        }
    }
}

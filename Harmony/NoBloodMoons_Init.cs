using HarmonyLib;
using HarmonyLib.Tools;
using System.Reflection;

namespace NoBloodMoons
{
    public class NoBloodMoons : IModApi
    {
        private static NoBloodMoons _context;

        internal static Mod ModInstance;

        public void InitMod(Mod modInstance)
        {
            _context = this;
            ModInstance = modInstance;
      
            var harmony = new Harmony(GetType().ToString());
#if DEBUG
            HarmonyFileLog.Enabled = true;
#endif            
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

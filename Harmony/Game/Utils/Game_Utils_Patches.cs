using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using HarmonyLib;
using NoBloodMoons.Scripts.Utils;

namespace NoBloodMoons.Game.Utils
{
    [HarmonyPatch(typeof(GameUtils))]
    public class GameUtilsPatches
    {
        [HarmonyTranspiler]
        [HarmonyPatch(nameof(GameUtils.IsBloodMoonTime), [typeof(ValueTuple<int, int>), typeof(int), typeof(int), typeof(int)])]
#if DEBUG
        [HarmonyDebug]
#endif
        private static IEnumerable<CodeInstruction> GameUtils_IsBloodMoonTime_Prime_Patch(IEnumerable<CodeInstruction> instructions)
        {
            // Patch is named Prime because it's the only one needed to disable blood moons.
            // The other method, for overloaded signatures, is not just patched for demonstration purposes.

            LogUtil.Info("Transpiler: IsBloodMoonTime.Prime always returns false.");
            // Replace method body with 'return false;'
            yield return new CodeInstruction(OpCodes.Ldc_I4_0);
            yield return new CodeInstruction(OpCodes.Ret);
        }

        [HarmonyTranspiler]
        //public static bool IsBloodMoonTime(ulong _worldTime, (int duskHour, int dawnHour) _duskDawnTimes, int _bmDay)
        [HarmonyPatch(nameof(GameUtils.IsBloodMoonTime), [typeof(ulong), typeof(ValueTuple<int, int>), typeof(int)])]
#if DEBUG
        [HarmonyDebug]
#endif
        private static IEnumerable<CodeInstruction> GameUtils_IsBloodMoonTime_Overload_Patch(IEnumerable<CodeInstruction> instructions)
        {
            // The Prime method patch is the only one needed for this to work, and this one is just patched for demonstration purposes.

            LogUtil.Info("Transpiler: IsBloodMoonTime.Overload always returns false.");
            // Replace method body with 'return false;'
            yield return new CodeInstruction(OpCodes.Ldc_I4_0);
            yield return new CodeInstruction(OpCodes.Ret);
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(GameUtils.IsBloodMoonTime), [typeof(ulong), typeof(ValueTuple<int, int>), typeof(int)])]
#if DEBUG
        [HarmonyDebug]
#endif
        private static bool Prefix_IsBloodMoonTime_Overload(ref bool __result)
        {
            LogUtil.DebugLog("Prefix: IsBloodMoonTime.Overload always returns false.");
            __result = false;
            return false; // Skip original method
        }
    }
}
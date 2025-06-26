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
        private static IEnumerable<CodeInstruction> GameUtils_IsBloodMoonTime_Patch(IEnumerable<CodeInstruction> instructions)
        {
            LogUtil.Info("Transpiler: IsBloodMoonTime always returns false.");
            // Replace method body with 'return false;'
            yield return new CodeInstruction(OpCodes.Ldc_I4_0);
            yield return new CodeInstruction(OpCodes.Ret);
        }
    }
}
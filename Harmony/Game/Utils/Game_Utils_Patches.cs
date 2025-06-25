using HarmonyLib;
using NoBloodMoons.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace NoBloodMoons.Game.Utils {
    [HarmonyPatch(typeof(GameUtils))]
    public class GameUtilsPatches
    {
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(GameUtils), nameof(GameUtils.IsBloodMoonTime), [typeof(ValueTuple<int, int>), typeof(int), typeof(int), typeof(int)])]
        //GameUtils.IsBloodMoonTime
#if DEBUG
        [HarmonyDebug]
#endif
        private static IEnumerable<CodeInstruction> GameUtils_IsBloodMoonTime_Patch(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var targetMethodString = $"{typeof(GameUtils)}.{nameof(GameUtils.IsBloodMoonTime)}";
            LogUtil.Info($"Transpiling {targetMethodString}");

            var code = instructions.ToList();
            List<CodeInstruction> newCode = [];
            
            newCode.Add(new CodeInstruction(OpCodes.Ldc_I4_0));
            newCode.Add(new CodeInstruction(OpCodes.Ret));

            code.InsertRange(0, newCode);
            return code.AsEnumerable();
        }
    }
}
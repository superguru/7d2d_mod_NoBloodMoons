using System;
using System.Runtime.CompilerServices;

namespace NoBloodMoons.Scripts.Utils
{
    public static class LogUtil
    {
        private const string Prefix = "[NoBloodMoons2]";

        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public static void Info(string text, [CallerMemberName] string caller = "")
        {
            LogMessage("Info", text, caller);
        }

        public static void Error(string text, Exception ex = null, [CallerMemberName] string caller = "")
        {
            var message = ex == null ? text : $"{text} Exception: {ex}";
            LogMessage("Error", message, caller);
        }

        public static void DebugLog(string text, [CallerMemberName] string caller = "")
        {
            if (IsDebug())
            {
                LogMessage("Debug", text, caller);
            }
        }

        public static void Warning(string text, [CallerMemberName] string caller = "")
        {
            LogMessage("Warn", text, caller);
        }

        private static void LogMessage(string level, string text, string caller)
        {
            var formatted = $"{Prefix}({level}) [{caller}] {text}";
            switch (level)
            {
                case "Error":
                    Log.Error(formatted);
                    break;
                case "Warn":
                    Log.Warning(formatted);
                    break;
                default:
                    Log.Out(formatted);
                    break;
            }
        }
    }
}

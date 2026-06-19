using System;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DialogInterceptorMod.Core
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        internal static string ConfigPath;

        // Log levels for structured logging
        public enum LogLevel { Debug, Info, Warning, Error }

        public void Awake()
        {
            try
            {
                Log = base.Logger;
                ConfigPath = Path.GetDirectoryName(base.Info.Location);
                LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION} initializing...");

                var harmony = new Harmony("com.agentesupersecreto.iachat");
                harmony.PatchAll();
                LogInfo("Harmony patches applied.");

                DialogBehaviour.Initialize();

                LogInfo("Plugin initialized successfully.");
            }
            catch (Exception ex)
            {
                LogError($"Error in Awake: {ex.Message}");
            }
        }

        public static void LogDebug(string msg) { Log?.LogDebug($"[D] {msg}"); }
        public static void LogInfo(string msg) { Log?.LogInfo($"[I] {msg}"); }
        public static void LogWarning(string msg) { Log?.LogWarning($"[W] {msg}"); }
        public static void LogError(string msg) { Log?.LogError($"[E] {msg}"); }
    }
}

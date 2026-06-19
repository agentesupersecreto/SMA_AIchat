using HarmonyLib;
using UnityEngine;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;
using DialogInterceptorMod.Core;

namespace DialogInterceptorMod.Patching
{
    internal static class HarmonyPatches
    {
        [HarmonyPatch(typeof(ControlladorDeBarkDePersonalidad), nameof(ControlladorDeBarkDePersonalidad.Bark))]
        [HarmonyPrefix]
        static void PrefixBark(ControlladorDeBarkDePersonalidad __instance, ref string dialogo)
        {
            Plugin.Log.LogInfo($"[Bark Emitido] {dialogo}");
        }

        // Block the game from hiding the cursor while our window is open
        [HarmonyPatch(typeof(Cursor), "set_visible")]
        [HarmonyPrefix]
        static bool PrefixCursorVisible(ref bool value)
        {
            if (DialogBehaviour.Instance != null && DialogBehaviour.Instance.Window != null && DialogBehaviour.Instance.Window.WindowVisible)
            {
                value = true;
                return true; 
            }
            return true;
        }

        // Block the game from locking the cursor while our window is open
        [HarmonyPatch(typeof(Cursor), "set_lockState")]
        [HarmonyPrefix]
        static bool PrefixCursorLockState(ref CursorLockMode value)
        {
            if (DialogBehaviour.Instance != null && DialogBehaviour.Instance.Window != null && DialogBehaviour.Instance.Window.WindowVisible)
            {
                value = CursorLockMode.None;
                return true;
            }
            return true;
        }
    }
}

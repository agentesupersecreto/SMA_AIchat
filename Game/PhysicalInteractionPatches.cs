using System;
using HarmonyLib;
using UnityEngine;
using DialogInterceptorMod.Core;
using DialogInterceptorMod.Models;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace DialogInterceptorMod.Game
{
    [HarmonyPatch(typeof(DesHielo))]
    public static class PhysicalInteractionPatches
    {
        private static float _lastTouchTime = 0f;
        private const float TOUCH_COOLDOWN = 15f; // Wait 15 seconds before notifying AI again

        [HarmonyPatch("SetTactilTo")]
        [HarmonyPrefix]
        public static void PrefixSetTactilTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloTactil subtipo)
        {
            try
            {
                // Only trigger if a positive value is applied, meaning an active touch, and it's being received
                if (value > 0f && direccion == DireccionDeEstimulo.recibida)
                {
                    if (Time.time - _lastTouchTime > TOUCH_COOLDOWN)
                    {
                        _lastTouchTime = Time.time;
                        NotifyAI(estimulada, subtipo);
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"Error in SetTactilTo patch: {ex.Message}");
            }
        }

        private static void NotifyAI(ParteDelCuerpoHumano estimulada, TipoDeEstimuloTactil tactil)
        {
            if (DialogBehaviour.Instance == null || DialogBehaviour.Instance.ChatHistory == null)
                return;

            string bodyPart = estimulada.ToString();
            string action = tactil.ToString();

            // Translate some common parts to English for better LLM comprehension
            if (bodyPart == "senos" || bodyPart == "pechos") bodyPart = "breasts";
            if (bodyPart == "labiosVaginales" || bodyPart == "vientreBajo") bodyPart = "crotch/genitals";
            if (bodyPart == "nalgas" || bodyPart == "trasero") bodyPart = "butt";
            if (bodyPart == "labios") bodyPart = "lips";

            // Translate actions
            if (action == "caricia") action = "caressing";
            if (action == "beso") action = "kissing";
            if (action == "lambida") action = "licking";
            if (action == "chupon") action = "sucking";
            if (action == "masaje") action = "massaging";
            if (action == "apreton") action = "squeezing";
            if (action == "nalgada") action = "spanking";

            string msg = $"[SYSTEM EVENT: The player is physically touching your {bodyPart}. Action: {action}. React to this physically or verbally.]";
            
            DialogBehaviour.Instance.ChatHistory.Add(ChatMessage.SystemMessage(msg));
            Plugin.Log.LogInfo($"Injected physical touch event: {msg}");
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using Assets;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;

namespace DialogInterceptorMod.Game
{
    public static class MovementHelper
    {
        public static string GoTo(Transform characterRoot, string targetId)
        {
            var instance = Singleton<GoToScenaManager>.instance;
            if (instance == null) return "GoTo system not available in this scene.";

            var goTo = instance.Obtener(targetId);
            if (goTo == null) return $"Location '{targetId}' not found.";

            var character = characterRoot.GetComponentInChildren<Character>();
            if (character == null) return "Character not found.";

            ICharacterNavegable navigable = character.GetComponentEnRoot<ICharacterNavegable>();
            if (navigable != null)
            {
                instance.NavTo(navigable, false, goTo, 1f, 1f, false);
                return $"Walking to '{targetId}'.";
            }

            instance.Apply(character, false, goTo);
            return $"Teleported to '{targetId}'.";
        }

        public static string GetAvailableGoToTargets()
        {
            var instance = Singleton<GoToScenaManager>.instance;
            if (instance == null) return "";

            var targets = new List<string>();
            foreach (var goTo in instance.registrados)
            {
                if (goTo.isValid && !goTo.hidden)
                    targets.Add(goTo.Id);
            }
            return string.Join(", ", targets);
        }
    }
}

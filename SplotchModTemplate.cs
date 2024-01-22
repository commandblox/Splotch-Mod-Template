using HarmonyLib;
using UnityEngine;
using Splotch;

namespace SplotchModTemplate
{
    public class SplotchModTemplate : Splotch.SplotchMod
    {
        public override void OnLoad()
        {
            Logger.Log("Hello Bopl Battle!");
            harmony.PatchAll(typeof(BasicPatch));
        }
    }

    [HarmonyPatch(typeof(Ability))]
    public class BasicPatch
    {
        [HarmonyPatch(nameof(Ability.EnterAbility))]
        [HarmonyPrefix]
        public void AbilityEnter()
        {
            Logger.Log("Entered ability!");
        }

        [HarmonyPatch(nameof(Ability.ExitAbility))]
        [HarmonyPrefix]
        public void AbilityExit()
        {
            Logger.Log("Exited ability!");
        }
    }
}

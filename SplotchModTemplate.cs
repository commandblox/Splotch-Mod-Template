using HarmonyLib;
using UnityEngine;

namespace SplotchModTemplate
{
    public class SplotchModTemplate : Splotch.SplotchMod
    {
        public override void OnLoad()
        {
            Debug.Log("Hello Bopl Battle!");
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
            Debug.Log("Entered ability!");
        }

        [HarmonyPatch(nameof(Ability.ExitAbility))]
        [HarmonyPrefix]
        public void AbilityExit()
        {
            Debug.Log("Exited ability!");
        }
    }
}

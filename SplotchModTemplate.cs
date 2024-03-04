using Splotch;
using Splotch.Event;
using Splotch.Event.PlayerEvents;
using HarmonyLib;
using BoplFixedMath;
using System.Reflection;

namespace SplotchModTemplate
{
    public class SplotchModTemplate : SplotchMod
    {
        public override void OnLoad()
        {
            Logger.Log("Hello Bopl Battle!");
            EventManager.RegisterEventListener(typeof(EventListener));
            Harmony.PatchAll(typeof(HarmonyPatches));
        }
    }
    public static class EventListener
    {
        [EventHandler]
        public static void OnPlayerDeath(PlayerDeathEvent deathEvent)
        {
            Logger.Log($"Player {deathEvent.GetPlayer().Color.name} died of {deathEvent.GetCauseOfDeath()}!");
        }

    }

    public static class HarmonyPatches
    {
        [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.Init))]
        [HarmonyPrefix]
        public static void PatchAccel(ref PlayerPhysics __instance)
        {
            FieldInfo PlatformSlipperyness01 = typeof(PlayerPhysics).GetField("PlatformSlipperyness01", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo IcePlatformSlipperyness01 = typeof(PlayerPhysics).GetField("IcePlatformSlipperyness01", BindingFlags.Instance | BindingFlags.NonPublic);
            IcePlatformSlipperyness01.SetValue(__instance, (Fix) 1.01);
            PlatformSlipperyness01.SetValue(__instance, (Fix) 1.01);
        }
    }
}

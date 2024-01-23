using Splotch;
using Splotch.Event;
using Splotch.Event.AbilityEvents;
using Splotch.Event.PlayerEvents;
using UnityEngine;

namespace SplotchModTemplate
{
    public class SplotchModTemplate : SplotchMod
    {
        public override void OnLoad()
        {
            Logger.Log("Hello Bopl Battle!");
            EventManager.RegisterEventListener(typeof(EventListener));

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
}

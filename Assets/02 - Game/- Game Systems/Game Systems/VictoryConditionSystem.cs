using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{

    public class VictoryConditionSystem : GameSystem
    {
        VictoryConditionSystem() => NotificationName = Notification.VICTORY_INC_SCORE;

        [SerializeField]
            GameObject victoriousPlayer;
        [Range(0,100)]
        public int currentTargets = 0, totalTargets = 3;

        protected override void NotificationHandler(object sender, object args)
            => IncreaseTarget();

        public void IncreaseTarget()
        {
            currentTargets++;
            string text = $"{currentTargets}/{totalTargets}";
            if (currentTargets == totalTargets)
            {
                text = "SUCESSO";
                Instantiate(victoriousPlayer, Vector3.zero, Quaternion.identity, null);
            }
            this.PostNotification(Notification.HUD_WRITE, text);
        }
        
    }
}
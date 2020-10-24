using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;
namespace innocent
{
    public class VictoryConditionSystem : GameSystem
    {
        [SerializeField] GameObject victoriousPlayer;
        public int currentTargets = 0, totalTargets = 3;
        private string NotificationName = Notification.VICTORY_INC_SCORE;

        #region Mono Behaviour

        void OnEnable() => this.AddObserver(CheckVictoryConditionOnNotification, NotificationName);

        void OnDisable() => this.RemoveObserver(CheckVictoryConditionOnNotification, NotificationName);
        #endregion

        #region Notification Handler
        void CheckVictoryConditionOnNotification(object sender, object args)
            => CheckVictoryCondition();
        #endregion

        #region Custom Methods
        public void CheckVictoryCondition()
        {
            IncreaseTarget();
        }
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
        #endregion
    }
}
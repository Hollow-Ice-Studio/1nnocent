using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class CollectableSystem : GameSystem
    {

        #region Const
        private const string MouseLeftNotification = Notification.MOUSE_LEFT_INPUT_NOTIFICATION;
        #endregion

        #region MonoBehaviour
        private void OnEnable()
        {
            this.AddObserver(OnMouseLeft, MouseLeftNotification);
        }

        void OnDisable()
        {
            this.RemoveObserver(OnMouseLeft, MouseLeftNotification);
        }
        #endregion

        #region Notification Handler
        void OnMouseLeft(object sender, object args)
        {
            this.PostNotification(Notification.TRY_COLLECT);
        }
        #endregion
    }
}


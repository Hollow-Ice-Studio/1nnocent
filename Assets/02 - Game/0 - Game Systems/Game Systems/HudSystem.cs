using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace innocent
{
    public class HudSystem : GameSystem
    {
        [SerializeField]
        Text UiTextElement;
        
        void Start() => this.AddObserver(WriteHudOnNotification, Notification.HUD_WRITE);

        #region Notification Handler
        void WriteHudOnNotification(object sender, object args) => UiTextElement.text = (string)args;
        #endregion

    }

}

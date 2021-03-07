using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace innocent
{
    public class HudTextSystem : GameSystem
    {   
        HudTextSystem() => NotificationName = Notification.HUD_WRITE;
        [SerializeField]
        public Text UiTextElement;
        
        protected override void NotificationHandler(object sender, object args)
            => UiTextElement.text = (string)args;

    }
}

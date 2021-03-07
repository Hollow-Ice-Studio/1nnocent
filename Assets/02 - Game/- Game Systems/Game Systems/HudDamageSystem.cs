using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace innocent
{
    public class HudDamageSystem : GameSystem
    {
        HudDamageSystem() => NotificationName = Notification.HUD_HURT;

        [SerializeField]
        public RawImage
            HurtMarkRawImage;
        [SerializeField]
        public Color
            HurtMarkColor;

        protected override void CacheReferences()
        {
            HurtMarkColor = HurtMarkRawImage.color;
            HurtMarkColor.a = 0;
            HurtMarkRawImage.color = HurtMarkColor;
            HurtMarkRawImage.gameObject.SetActive(true);
        }

        protected override void NotificationHandler(object sender, object args = null)
            => StartCoroutine(TemporaryHurtDisplay(3));

        public IEnumerator TemporaryHurtDisplay(float waitTime)
        {
            HurtMarkColor.a = 1;
            float divisor = 5;
            float dividedTime = (waitTime / divisor);
            for (float i = 0; i < waitTime; i += dividedTime)
            {
                HurtMarkColor.a -= (1 / divisor);
                HurtMarkRawImage.color = HurtMarkColor;
                yield return new WaitForSeconds(dividedTime);
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace innocent
{
    public class HudInsanitySystem : GameSystem
    {
        HudInsanitySystem() => NotificationName = Notification.HUD_INSANITY;

        [SerializeField]
        public RawImage
            InsanityMarkRawImage;
        [SerializeField]
        public Color
            InsanityColor;

        protected override void CacheReferences()
        {
            InsanityColor = InsanityMarkRawImage.color;
            InsanityColor.a = 0;
            InsanityMarkRawImage.color = InsanityColor;
            InsanityMarkRawImage.gameObject.SetActive(true);
        }

        protected override void NotificationHandler(object sender, object args = null)
            => StartCoroutine(TemporaryInsanityDisplay(3, 6));


        public IEnumerator TemporaryInsanityDisplay(float waitTime, float timeBeforeHealing)
        {
            InsanityColor.a = 1;
            InsanityMarkRawImage.color = InsanityColor;
            yield return new WaitForSeconds(timeBeforeHealing);
            float divisor = 5;
            float dividedTime = (waitTime / divisor);
            for (float i = 0; i < waitTime; i += dividedTime)
            {
                InsanityColor.a -= (1 / divisor);
                InsanityMarkRawImage.color = InsanityColor;
                yield return new WaitForSeconds(dividedTime);
            }
        }

    }
}

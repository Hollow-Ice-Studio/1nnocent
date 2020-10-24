using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace innocent
{
    public class HudSystem : GameSystem
    {
        [SerializeField]  Text UiTextElement;
        [SerializeField]
        RawImage 
            HurtMarkRawImage,
            InsanityMarkRawImage;
        Color
            HurtMarkColor,
            InsanityColor;

        void Start()
        {
            CacheReferences();
            AddObservers();
        }
        void OnDestroy()
        {
            RemoveObservers();
        }

        void CacheReferences()
        {
            HurtMarkColor = HurtMarkRawImage.color;
            HurtMarkColor.a = 0;
            HurtMarkRawImage.color = HurtMarkColor;
            HurtMarkRawImage.gameObject.SetActive(true);
            InsanityColor = InsanityMarkRawImage.color;
            InsanityColor.a = 0;
            InsanityMarkRawImage.color = InsanityColor;
            InsanityMarkRawImage.gameObject.SetActive(true);
        }

        void AddObservers()
        {
            this.AddObserver(WriteHudOnNotification, Notification.HUD_WRITE);
            this.AddObserver(DisplayHudMarkOnNotification, Notification.HUD_HURT);
            this.AddObserver(DisplayInsanityMarkOnNotification, Notification.HUD_INSANITY);
        }

        void RemoveObservers()
        {
            this.RemoveObserver(WriteHudOnNotification, Notification.HUD_WRITE);
            this.RemoveObserver(DisplayHudMarkOnNotification, Notification.HUD_HURT);
            this.RemoveObserver(DisplayInsanityMarkOnNotification, Notification.HUD_INSANITY);
        }

        #region Notification Handler
        void WriteHudOnNotification(object sender, object args)
        {
            UiTextElement.text = (string)args;
        }
        void DisplayHudMarkOnNotification(object sender, object args=null)
        {
            StartCoroutine(TemporaryHurtDisplay(3));
        }
        void DisplayInsanityMarkOnNotification(object sender, object args=null)
        {
            StartCoroutine(TemporaryInsanityDisplay(2));
        }
        #endregion

        #region Custom Methods

        private IEnumerator TemporaryHurtDisplay(float waitTime)
        {
            HurtMarkColor.a = 1;
            float divisor = 5;
            float dividedTime = (waitTime / divisor);
            for (float i=0;i < waitTime; i += dividedTime)
            {
                HurtMarkColor.a -= (1 / divisor);
                HurtMarkRawImage.color = HurtMarkColor;
                yield return new WaitForSeconds(dividedTime);
            }
        }

        private IEnumerator TemporaryInsanityDisplay(float waitTime)
        {
            InsanityColor.a = 1;
            float divisor = 5;
            float dividedTime = (waitTime / divisor);
            float alpha = 0;
            for (float i = 0; i < waitTime; i += dividedTime)
            {
                alpha += 1 / 5;
                InsanityColor.a = alpha;
                InsanityMarkRawImage.color = InsanityColor;
                yield return new WaitForSeconds(dividedTime);
            }
        }
        #endregion
    }

}

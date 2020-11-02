using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.Notifications;
namespace innocent
{
    public class AudioSystem : GameSystem
    {
        AudioSource AudioSourceComponent;

        void Start()
        {
            AudioSourceComponent = GetComponent<AudioSource>();
            this.AddObserver(PlayAudionOnNotification,Notification.AUDIO_PLAY);
        }

        void OnDestroy() => this.RemoveObserver(PlayAudionOnNotification, Notification.AUDIO_PLAY);

        #region Notification Handler
        void PlayAudionOnNotification(object sender, object args)
        { 
            AudioSourceComponent.clip = (AudioClip)args;
            AudioSourceComponent.Play();
        }
        #endregion

    }
}
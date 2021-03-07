using UnityEngine;
using TheLiquidFire.Notifications;

namespace innocent
{
    public class AudioSystem : GameSystem
    {
        AudioSystem() => NotificationName = Notification.AUDIO_PLAY;

        public AudioSource AudioSourceComponent;
        
        protected override void NotificationHandler(object sender, object args)
        {
            AudioSourceComponent.clip = (AudioClip)args;
            AudioSourceComponent.Play();
        }

        protected override void CacheReferences() 
            => AudioSourceComponent = AudioSourceComponent != null ? AudioSourceComponent : GetComponent<AudioSource>();
        
    }
}
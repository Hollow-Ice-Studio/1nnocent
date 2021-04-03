using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using TheLiquidFire.Notifications;
namespace innocent
{
    public class AudioTrigger : MonoBehaviour
    {
        [SerializeField] AudioClip AudioToPlay;
        [SerializeField, ReadOnly] string PlayerTag = "Player";
        bool IsActivated = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsActivated && other.tag.Equals(PlayerTag))
            {
                this.PostNotification(Notification.AUDIO_PLAY, AudioToPlay);
                IsActivated = true;
            }
        }
    }
}
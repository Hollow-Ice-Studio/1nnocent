using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.Playables;

namespace innocent
{
    public class CutSceneDetector : MonoBehaviour
    {
        [SerializeField] PlayableAsset cutscene;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                this.PostNotification(Notification.CUTSCENE_PLAY, cutscene);
                Destroy(this);
            }
        }
    }
}
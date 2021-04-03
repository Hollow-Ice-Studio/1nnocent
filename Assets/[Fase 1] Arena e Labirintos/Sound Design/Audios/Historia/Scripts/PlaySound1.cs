using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent {
    public class PlaySound1 : MonoBehaviour
    {
        public string TextoDeSinalizacao = "Vire a esquerda, pegue a arma";
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("2aparte");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound5B : MonoBehaviour
    {
        public string TextoDeSinalizacao = "É matar ou morrer! Derrote o inimigo e siga em frente.";
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Inimigo Perto");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
            }
        }
    }
}
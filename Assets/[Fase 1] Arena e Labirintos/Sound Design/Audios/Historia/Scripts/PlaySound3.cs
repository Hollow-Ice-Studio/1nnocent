using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound3 : MonoBehaviour
    {
        public string TextoDeSinalizacao = "Adam, perdemos o acesso à esse trecho. Encontre uma saída.";
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Perder Acesso");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
                Destroy(this);
            }
        }
    }
}
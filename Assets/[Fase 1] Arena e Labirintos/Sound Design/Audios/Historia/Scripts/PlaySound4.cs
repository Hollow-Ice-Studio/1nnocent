using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound4 : MonoBehaviour
    {
        public string TextoDeSinalizacao = "Use pontos altos para se localizar.";
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Labirinto Facil");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
            }
        }
    }
}
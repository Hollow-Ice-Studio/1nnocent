using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound5 : MonoBehaviour
    {
        public string TextoDeSinalizacao = "Esta é uma K41N. Te ajudará a se proteger.";
        [SerializeField]
        GameObject firstStoryEnemy, nextAudioTrigger;
        private void Start()
        {
            firstStoryEnemy.SetActive(false);
            nextAudioTrigger.SetActive(false);
        }
        void OnTriggerEnter(Collider coll)
        {

            if (coll.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Pegar Arma");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
                firstStoryEnemy.SetActive(true);
                nextAudioTrigger.SetActive(true);
            }
        }
    }
}
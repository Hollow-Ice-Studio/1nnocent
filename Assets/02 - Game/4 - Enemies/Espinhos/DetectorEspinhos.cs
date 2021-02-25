using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class DetectorEspinhos : MonoBehaviour
    {
        [SerializeField] AudioClip EfeitoSonoro;
        [SerializeField] GameObject Espinhos;
        [SerializeField] float maxVelocity;
        Animator espinhosAnim;

        void Start()
        {
            espinhosAnim = Espinhos.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                Perigo();
                if (collider.GetComponent<Animator>().GetBool("isRunning"))
                    Ativar();
                this.LogWithColor(collider.GetComponent<Animator>().GetBool("isRunning"), "cyan");
            }
        }

        void Perigo()
        {
            this.LogWithColor("Jogador entrou na área de perigo", "yellow");
            espinhosAnim.SetTrigger("Perigo");
        }

        void Ativar()
        {
            this.LogWithColor("Armadilha ativou", "red");
            espinhosAnim.SetTrigger("Ativar");
            this.PostNotification(Notification.SOUND_EFFECT_PLAY, EfeitoSonoro);
        }
    }
}
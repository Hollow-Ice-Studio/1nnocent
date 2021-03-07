using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class DetectorEspinhos : MonoBehaviour
    {
        AudioSource audioSource;
        [Range(0,2f)]
        [SerializeField]
            float audioDelay = 0.6f;
        Animator espinhosAnim;

        void Start()
        {
            espinhosAnim = GetComponentInParent<Animator>();
            audioSource  = GetComponent<AudioSource>();
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
            audioSource.PlayDelayed(audioDelay);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Onennocent/Gun", order = 1)]
    public class Gun_ᛊᛟ : ScriptableObject
    {
        public string
            description = "Gun Name";
        public float
            impulse = 50,
            distance = 1000,
            totalAmmo = 16,
            currentAmmo = 0;
        public AudioClip
            shootingSound,
            reloadingSound;
        public GameObject 
            bulletHole;

        public AnimatorOverrideController AnimatorOverride;

        void PlayShootSound(AudioSource audioSource)
        {
            audioSource.clip = shootingSound;
            audioSource.Play();
        }

        void PlayReloadingSound(AudioSource audioSource)
        {
            audioSource.clip = reloadingSound;
            audioSource.Play();
        }

        public bool TryShoot(Transform from,AudioSource audioSource)
        {
            bool sucess = false;
            if (sucess = currentAmmo <= 0)
            {
                currentAmmo = totalAmmo;
                PlayReloadingSound(audioSource);
            }
            else
            {
                currentAmmo--;
                Shoot(from);
                PlayShootSound(audioSource);
            }
            this.PostNotification(Notification.HUD_WRITE, $"{description} {currentAmmo}/{totalAmmo}");
            return sucess;
        }

        void Shoot(Transform from)
        {
            Ray ray = new Ray(from.position, from.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
            {
                var inverseHittedFaceDirection = hitInfo.normal * impulse * -1;
                var bh = Instantiate(bulletHole, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Debug.Log(bh);
                var collidedCollider = hitInfo.collider;
                var collidedRigidBody = collidedCollider?.GetComponent<Rigidbody>();
                if (collidedRigidBody) collidedRigidBody.AddForce(inverseHittedFaceDirection);
                if (collidedCollider?.tag == "Target")
                {
                    collidedCollider.tag = "Untagged";
                    //todo: tranformar em propriedade privada e cacheada
                    MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
                    materialPropertyBlock.SetColor("_Color", new Color(0, 1, 0));
                    var meshRend = collidedCollider.GetComponent<MeshRenderer>();
                    if (meshRend != null)
                        meshRend?.SetPropertyBlock(materialPropertyBlock);
                    var animator = collidedCollider.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator?.SetTrigger("Die");
                        //FindObjectOfType<AudioManager>().Play("Depois de matar");
                        //Gambi: consertar no futuro
                        var adam = FindObjectOfType<ThirdPersonAnimationController>();
                        adam.IncreaseAgonyLevelOnAnimationActivation(true);
                        //this.PostNotification(Notification.HUD_INSANITY);
                    }
                    //this.PostNotification(Notification.VICTORY_INC_SCORE);
                }
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;
namespace innocent
{
    [RequireComponent(typeof(AudioSource))]
    public class GunController : MonoBehaviour
    {
        [SerializeField] Gun gun;
        [SerializeField] Transform bulletHole;

        AudioSource audioSource;
        const string
            EnemyLayerMask = "Enemy",
            TargetTagName = "Target",
            UntaggedTagName = "Untagged";

        #region Mono Behaviour
        void Awake() => Build();
        
        void Update()
        {
            Debug.DrawRay(bulletHole.position, transform.forward * 10, Color.green);
            if (Input.GetButtonDown(ConfiguredButtonNames.SHOOT))
                TryShoot();
        }
        #endregion

        void Build()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void PlayShootSound()
        {
            audioSource.clip = gun.shootingSound;
            audioSource.Play();
        }
        public void PlayReloadingSound()
        {
            audioSource.clip = gun.reloadingSound;
            audioSource.Play();
        }

        void TryShoot()
        {
            if (gun.currentAmmo <= 0)
            {
                gun.currentAmmo = gun.totalAmmo;
                PlayReloadingSound();
            }
            else
            {
                gun.currentAmmo--;
                PlayShootSound();
                Shoot();
            }
            var description = $"{gun.description} {gun.currentAmmo}/{gun.totalAmmo}";
            this.PostNotification(Notification.HUD_WRITE, description);
        }

        public void Shoot()
        {
            LayerMask enemyMask = LayerMask.GetMask(EnemyLayerMask);
            Ray ray = new Ray(bulletHole.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, gun.distance))
            {
                var inverseHittedFaceDirection = hitInfo.normal * gun.impulse * -1;
                var collidedCollider = hitInfo.collider;
                var collidedRigidBody = collidedCollider?.GetComponent<Rigidbody>();
                if(collidedRigidBody) collidedRigidBody.AddForce(inverseHittedFaceDirection); 
                if (collidedCollider?.tag == TargetTagName)
                {
                    
                    collidedCollider.tag = UntaggedTagName;
                    //todo: tranformar em propriedade privada e cacheada
                    MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
                    materialPropertyBlock.SetColor("_Color", new Color(0, 1, 0));
                    collidedCollider.GetComponent<MeshRenderer>().SetPropertyBlock(materialPropertyBlock);
                    this.PostNotification(Notification.VICTORY_INC_SCORE);
                }
            }
        }
    }
}

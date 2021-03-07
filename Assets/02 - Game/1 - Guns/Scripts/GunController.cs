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
        [SerializeField]
           public Gun_ᛊᛟ gun;
        [SerializeField]
            Transform gunBarrelExit;
        LineRenderer laser;
        AudioSource audioSource;
        bool canShoot = true;

        #region Mono Behaviour
        void Start() => CacheReferences();
        void Update() => ShootAndAim();
        #endregion

        void CacheReferences()
        {
            audioSource = GetComponent<AudioSource>();
            laser = GetComponent<LineRenderer>();
            gunBarrelExit = gunBarrelExit != null ? gunBarrelExit : transform;
        }

        void ShootAndAim()
        {
            Debug.DrawRay(gunBarrelExit.position, gunBarrelExit.forward * 10, Color.green);
            if (Input.GetButton(ConfiguredButtonNames.AIM) &&
                Input.GetButtonDown(ConfiguredButtonNames.SHOOT))
            {
                if (canShoot && gun.TryShoot(gunBarrelExit, audioSource))
                {

                }
                else
                {

                }
            }
        }   
    }
}

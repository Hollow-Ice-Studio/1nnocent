using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;
namespace innocent
{
    public class TriggerDetector : MonoBehaviour
    {
        protected bool isInside = false;
        protected string pertibleTag = "Player";

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == pertibleTag)
            {
                isInside = true;
                DoOnDetectionEnter(other);
            }
        }
        void OnTriggerStay(Collider other)
        {
            if (isInside)
            {
                DoOnDetectionStay(other);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == pertibleTag)
            {
                isInside = false;
                DoOnDetectionExit(other);
            }
        }
        protected virtual void DoOnDetectionEnter(Collider other) { }
        protected virtual void DoOnDetectionExit(Collider other) { }
        protected virtual void DoOnDetectionStay(Collider other) { }
    }

    public class PickableObjectDetector : TriggerDetector
    {
        [SerializeField]
        GameObject 
            pickablePrefabVersion,
            equipablePrefabVersion;
        [SerializeField]
            KeyCode buttonToPick;
        public string showText = "Pressione";


        protected override void DoOnDetectionEnter(Collider other)
            => this.PostNotification(Notification.HUD_WRITE,
                    $"{showText}\n [{buttonToPick.ToString()}]");
        
        protected override void DoOnDetectionExit(Collider other)
            => this.PostNotification(Notification.HUD_WRITE,"");
        
        protected override void DoOnDetectionStay(Collider other)
        {
            if (Input.GetKey(buttonToPick))
            {
                this.PostNotification(Notification.HUD_WRITE, "");
                var weaponSlot = other.GetComponent<ThirdPersonWeaponSlotsController>();
                weaponSlot.ChangeWeapon(equipablePrefabVersion, pickablePrefabVersion);
                Destroy(gameObject);
            }
        }
    }
}


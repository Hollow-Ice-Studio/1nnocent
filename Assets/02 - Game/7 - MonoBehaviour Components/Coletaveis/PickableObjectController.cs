using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;
namespace innocent
{
    public class PickableObjectController : MonoBehaviour
    {
        [SerializeField]
        GameObject pickablePrefabVersion;
        [SerializeField]
        GameObject equipablePrefabVersion;
        [SerializeField]
        KeyCode buttonToPick;
        public string showText;

        private bool isInside = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                isInside = true;
                this.PostNotification(Notification.HUD_WRITE,
                    $"{showText}\n [{buttonToPick.ToString()}]");
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                isInside = false;
                this.PostNotification(Notification.HUD_WRITE,"");
            }
        }
        void OnTriggerStay(Collider other)
        {
            if (isInside && Input.GetKey(buttonToPick))
            {
                this.PostNotification(Notification.HUD_WRITE, "");
                var weaponSlot = other.GetComponent<ThirdPersonWeaponSlotsController>();
                weaponSlot.ChangeWeapon(equipablePrefabVersion, pickablePrefabVersion);
                Destroy(gameObject);
            }
        }
    }
}


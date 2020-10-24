using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.Notifications;
using UnityEngine.UI;
namespace innocent {
    [RequireComponent(typeof(Character))]
    public class ThirdPersonDamageController : MonoBehaviour
    {
        [Header("Adicione uma referência")]
        [SerializeField]
        GameObject DyingModelPrefab;
        Character Character;

        void Start()
        {
            Character = GetComponent<Character>();
            if (DyingModelPrefab == null)
                throw new System.Exception("Adicione uma prefab no script");
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (Character.LifeValue <= 0)
                    die();
                else
                    hurt();
            }
        }

        void hurt()
        {
            Character.LifeValue--;
            this.PostNotification(Notification.HUD_HURT);
        }

        void die()
        {
            Instantiate(DyingModelPrefab, this.transform.position, this.transform.rotation, null);
            Destroy(this.gameObject);
        }
    }
}
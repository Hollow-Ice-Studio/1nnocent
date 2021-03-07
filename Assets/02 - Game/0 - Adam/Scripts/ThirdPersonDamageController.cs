using UnityEngine;
using TheLiquidFire.Notifications;

namespace innocent
{
    [RequireComponent(typeof(Adam))]
    public class ThirdPersonDamageController : MonoBehaviour
    {
        [Header("Adicione uma referência")]
        [SerializeField]
        GameObject DyingModelPrefab;
        [Range(0,1000)]
        public float limiteVerticalDoMapa;
        Adam adam;
        

        void Start()
        {
            adam = GetComponent<Adam>();
            if (DyingModelPrefab == null)
                throw new System.Exception("Adicione uma prefab no script");
        }

        void Update()
        {
            if(transform.position.y < -limiteVerticalDoMapa
                || transform.position.y > limiteVerticalDoMapa)
            {
                die();
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == ConfiguredTags.ENEMY)
            {
                if (adam.LifeValue <= 0)
                    die();
                else
                    hurt();
            }
        }

        void hurt()
        {
            adam.LifeValue--;
            this.PostNotification(Notification.HUD_HURT);
        }

        void die()
        {
            Instantiate(DyingModelPrefab, this.transform.position, this.transform.rotation, null);
            Destroy(this.gameObject);
        }
    }
}
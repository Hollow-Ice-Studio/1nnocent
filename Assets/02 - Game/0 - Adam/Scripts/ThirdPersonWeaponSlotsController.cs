using UnityEngine;

namespace innocent
{
    [RequireComponent(typeof(Animator))]
    public class ThirdPersonWeaponSlotsController : MonoBehaviour
    {
        [SerializeField]
        Transform handPosition;
        [SerializeField]
        GameObject currentWeapon, pickableVersion;
        public string animatorLayerName;
        Animator animator;
        AnimatorOverrideController animatorOverrideController;

        void Awake()
        {
            animator = GetComponent<Animator>();
            animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }

        void LateUpdate()
        {
            if (currentWeapon != null && Input.GetMouseButton(1))
            {

                //animator.SetLayerWeight(animator.GetLayerIndex("Pistol Layer"), 1);
                //animator.SetLayerWeight(animator.GetLayerIndex("Recoil"), 1);
                GunController gc = currentWeapon?.GetComponent<GunController>();
                animator.runtimeAnimatorController = gc.gun.AnimatorOverride;
                animator.Update(0f);
                gc.enabled = true;
            }
            else
            {
                //animator.SetLayerWeight(animator.GetLayerIndex("Pistol Layer"), 0);
                //animator.SetLayerWeight(animator.GetLayerIndex("Recoil"), 0);
                animator.runtimeAnimatorController = animatorOverrideController;
                animator.Update(0f);
                if (currentWeapon != null)
                {
                    GunController gc = currentWeapon.GetComponent<GunController>();
                    gc.enabled = false;
                }

            }
            if (currentWeapon != null && Input.GetKeyDown(KeyCode.P))
            {
                //TODO: pensar em como aplicar isso
                Instantiate(pickableVersion, this.transform.position, this.transform.rotation, null);
            }
        }
        public void ChangeWeapon(GameObject newWeapon, GameObject newPickable)
        {
            pickableVersion = newPickable;
            currentWeapon = newWeapon;
            if (currentWeapon)
                currentWeapon = GameObject.Instantiate(currentWeapon, handPosition);
        }

    }
}

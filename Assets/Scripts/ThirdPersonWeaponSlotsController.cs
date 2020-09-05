using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThirdPersonWeaponSlotsController : MonoBehaviour
{
    [SerializeField]
    Transform handPosition;
    [SerializeField]
    GameObject currentWeapon, pickableVersion;
    public string animatorLayerName;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (currentWeapon!=null && Input.GetMouseButton(1))
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Pistol Layer"), 1);
            animator.SetLayerWeight(animator.GetLayerIndex("Recoil"), 1);
            GunController gc = currentWeapon?.GetComponent<GunController>();
            gc.enabled = true;
        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Pistol Layer"), 0);
            animator.SetLayerWeight(animator.GetLayerIndex("Recoil"), 0);
            if(currentWeapon != null)
            {
                GunController gc = currentWeapon.GetComponent<GunController>();
                gc.enabled = false;
            }
            
        }
        if (currentWeapon != null && Input.GetKeyDown(KeyCode.P))
        {
            //TODO: pensar em como aplicar isso
            Instantiate(pickableVersion,this.transform.position,this.transform.rotation, null);
        }
    }
    public void ChangeWeapon(GameObject newWeapon,GameObject newPickable)
    {
        pickableVersion = newPickable;
        currentWeapon = newWeapon;
        if (currentWeapon)
            currentWeapon = GameObject.Instantiate(currentWeapon, handPosition);
    }

}

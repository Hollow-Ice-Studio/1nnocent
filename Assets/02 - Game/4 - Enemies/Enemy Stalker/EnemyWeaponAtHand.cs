using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponAtHand : MonoBehaviour
{
    private const string ENEMY_WEAPON_TAG = "Enemy Weapon";
    [SerializeField] private Weapon currentWeapon;
    public Weapon CurrentWeapon { get { return currentWeapon; } set { currentWeapon = value; } }

    private SphereCollider grabCollider;

    private void Awake()
    {
        this.tag = ENEMY_WEAPON_TAG;
        grabCollider = GetComponent<SphereCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            //EvaluateWeapon(other.gameObject);
            //gambi: Coloquei para apagar a arma encontrada e habilitar uma arma que ja esta na mão do adam. (com o mesh bonitinho, antes desabilitado); 
            Destroy(other.transform.parent.gameObject);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            currentWeapon = gameObject.transform.GetChild(0)?.GetComponent<Weapon>();
        }
    }

    void EvaluateWeapon(GameObject weaponObj)
    {
        Weapon weapon = weaponObj.GetComponentInParent<Weapon>();
        if (weapon.Owner == null && currentWeapon == null) {
            currentWeapon = weapon;
            weapon.Owner = this.gameObject;
            weapon.transform.parent = this.transform;
        }
    }

}

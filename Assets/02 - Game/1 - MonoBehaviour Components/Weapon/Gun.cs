using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    const string PREFAB_PATH = "Prefabs/Bullet/Bullet Prefab";
    bool isRunning;
    IEnumerator coroutine;

    private void Update() {
        Debug.Log($"Gun local position {gameObject.transform.position}");
    }

    public override void Attack(GameObject targetObj)
    {
        if (!isRunning)
        {
            coroutine = AttackRoutine(targetObj);
            StartCoroutine(coroutine);
        }

    }

    IEnumerator AttackRoutine(GameObject targetObj)
    {
        isRunning = true;
        yield return new WaitForSeconds(3.0f);
        Debug.Log($"Enemy {owner.name} Try attack player");

        GameObject bulletObj = Instantiate(Resources.Load<GameObject>(PREFAB_PATH), transform.localPosition, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.transform.localPosition = gameObject.transform.position;

        bullet.OriginPos = transform.localPosition;
        bullet.TargetPos = targetObj.transform.localPosition;
        isRunning = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Weapon
{
    const string PREFAB_PATH = "Prefabs/Bullet/Bullet Prefab";
    bool isRunning;
    IEnumerator coroutine;

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
        // Atira num intervalo de 0.5 a 3 segundos, apenas para adicionar variedade na cadência de tiros
        // Vocês podem melhorar isso através dos ScriptableObjects de armas
        yield return new WaitForSeconds(3f);

        if (targetObj != null)
        {
            audioSource.Play();
            BuildProjectile(targetObj);
        }
    }

    void BuildProjectile(GameObject targetObj)
    {
        
        GameObject bulletObj = Instantiate(Resources.Load<GameObject>(PREFAB_PATH), transform.localPosition, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.transform.localPosition = gameObject.transform.position;

        bullet.OriginPos = transform.localPosition;

        // Solução hard coded para projétil não mirar no pé do jogador
        bullet.TargetPos = new Vector3(
            targetObj.transform.localPosition.x,
            targetObj.transform.localPosition.y + 1f,
            targetObj.transform.localPosition.z);

        bullet.Shoot();

        isRunning = false;
    }
}

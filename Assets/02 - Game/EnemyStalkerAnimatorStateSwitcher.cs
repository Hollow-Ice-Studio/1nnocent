using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyStalkerAnimatorStateSwitcher : MonoBehaviour
{
    private EnemyStalker owner;
    public EnemyStalker Owner { get { return owner; } set { owner = value; } }
    private Animator animator;
    void Start()
        => animator = GetComponent<Animator>();
    void FixedUpdate()
        => ChangeEnemyAnimationState();

    void ChangeEnemyAnimationState()
    {
        if (Owner != null && Owner.CurrentState == EnemyState.FIND_WEAPON)
        {
            animator.SetLayerWeight(1, 0);//Seta a layer de mirando sem interferencia
        }
        else
        {
            if (Owner.enemyWeapon.CurrentWeapon != null)
                animator.SetLayerWeight(1, 1);//Seta a layer de mirando com interferencia
        }
    }
}

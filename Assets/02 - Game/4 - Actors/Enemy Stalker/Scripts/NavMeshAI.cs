using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 defaultDestinationPoint;
    private GameObject playerObj;
    public GameObject PlayerObj { set { playerObj = value; } }
    private EnemyStalker owner;
    public EnemyStalker Owner { get { return owner; } set { owner = value; } }
    private EnemyState currentState;
    public EnemyState CurrentState { set { currentState = value; } }
    public bool Arrived;

    private void Awake()
    {

        agent = GetComponentInParent<NavMeshAgent>();
        if (agent == null)
            throw new MissingComponentException("Adicione um NavMeshAgent ao objeto");
        // defaultDestinationPoint = new Vector3(110, 5, 205);
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.FIND_WEAPON:
                FindWeapon();
                break;
            case EnemyState.STALK:
                Stalk();
                break;
            case EnemyState.SCOUT:
                Arrived = false;
                Scout();
                break;
            default:
                break;
        }
    }

    void FindWeapon()
    {
        Weapon destination = owner.AvailableWeapons
        .OrderBy(w => Vector3.SqrMagnitude(w.transform.position - transform.position))
        .Where(w => w.Owner == null)
        .FirstOrDefault();

        if (destination != null)
        {
            agent.SetDestination(destination.gameObject.transform.position);
        }
    }

    void Stalk()
    {
        if (playerObj != null)
            agent.SetDestination(playerObj.transform.position);
    }

    void Scout()
    {
        // Rotina placeholder, deve ser substituida por lógica de patrulhar área
        FindWeapon();
    }

    Vector3 CompareDistance(Vector3 target, Vector3 owner)
    {
        return new Vector3(Mathf.Abs(target.x - owner.x), Mathf.Abs(target.y - owner.y), Mathf.Abs(target.z - owner.z));
    }
}

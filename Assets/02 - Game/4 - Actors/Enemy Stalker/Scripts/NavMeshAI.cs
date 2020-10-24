using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{

    private NavMeshAgent agent;
    private Vector3 defaultDestinationPoint;
    private GameObject playerObj;
    public GameObject PlayerObj { set { playerObj = value; } }
    private EnemyState currentState;
    public EnemyState CurrentState { set { currentState = value; } }
    public bool Arrived;

    private void Awake()
    {

        agent = GetComponentInParent<NavMeshAgent>();
        if (agent == null)
            throw new MissingComponentException("Adicione um NavMeshAgent ao objeto");

        defaultDestinationPoint = new Vector3(110, 5, 205);
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
        agent.SetDestination(defaultDestinationPoint);

        // Rotina placeholder, deve ser substituida por lógica de equipar arma
        float x = Mathf.Abs(agent.transform.localPosition.x - defaultDestinationPoint.x);
        float z = Mathf.Abs(agent.transform.localPosition.z - defaultDestinationPoint.z);
        if (x + z <= 5f)
        {
            Arrived = true;
        }

    }

    void Stalk()
    {
        agent.SetDestination(playerObj.transform.localPosition);
    }

    void Scout()
    {
        // Rotina placeholder, deve ser substituida por lógica de patrulhar área
        FindWeapon();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    FIND_WEAPON,
    SCOUT,
    STALK
}
public class EnemyStalker : MonoBehaviour
{
    private const string ARENA_TAG = "Arena";
    private const string PLAYER_TAG = "Player";

    private NavMeshAI navMeshAI;
    private ArenaCollider arenaCollider;
    private GameObject playerObj;
    [SerializeField] private EnemyState currentState;
    public EnemyState CurrentState { get { return currentState; } }

    private void Awake()
    {
        CheckComponents();
        navMeshAI.PlayerObj = playerObj;
        UpdateState(EnemyState.FIND_WEAPON);
    }

    void CheckComponents()
    {
        navMeshAI = GetComponentInChildren<NavMeshAI>();
        if (navMeshAI == null)
            throw new MissingComponentException("Adicione um NavMeshAI como filho deste objeto");

        GameObject arenaObj = GameObject.FindGameObjectWithTag(ARENA_TAG);
        if (arenaObj == null)
            throw new MissingReferenceException("Adicione o prefab Arena Collider à cena");

        playerObj = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        if (playerObj == null)
            throw new MissingReferenceException("Adicione o prefab do Jogador à cena");

        arenaCollider = arenaObj.GetComponent<ArenaCollider>();
    }

    private void Update()
    {
        PublishState();
        EvaluateActions();
    }

    private void EvaluateActions()
    {
        if (navMeshAI.Arrived && arenaCollider.PlayerOnTheRange) {
            UpdateState(EnemyState.STALK);
            return;
        }

        if (navMeshAI.Arrived && !arenaCollider.PlayerOnTheRange) {
            UpdateState(EnemyState.SCOUT);
            return;
        }
            
    }

    private void UpdateState(EnemyState newState)
    {
        currentState = newState;
    }

    private void PublishState()
    {
        navMeshAI.CurrentState = currentState;
    }
}

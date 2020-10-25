using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [Tooltip("Área do mapa em que o inimigo surge")]
    [SerializeField] private MapSection mapSection;
    private NavMeshAI navMeshAI;
    private EnemyWeapon enemyWeapon;
    private ArenaCollider arenaCollider;
    private GameObject playerObj;
    [SerializeField] private EnemyState currentState;
    public EnemyState CurrentState { get { return currentState; } }

    [SerializeField] private List<Weapon> availableWeapons;
    private void Awake()
    {
        CheckComponents();
        navMeshAI.PlayerObj = playerObj;
        ScanWeapons();
    }

    void CheckComponents()
    {
        navMeshAI = GetComponentInChildren<NavMeshAI>();
        if (navMeshAI == null)
            throw new MissingComponentException("Adicione um NavMeshAI como filho deste objeto");

        enemyWeapon = GetComponentInChildren<EnemyWeapon>();
        if (enemyWeapon == null)
            throw new MissingComponentException("Adicione um EnemyWeapon como filho deste objeto");

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

    private void ScanWeapons() {
        availableWeapons = GameObject.FindGameObjectsWithTag("Weapon").ToList()
        .Where(obj => {
            Weapon weapon = obj.GetComponent<Weapon>();
            return weapon != null && weapon.MapSection == mapSection;
        })
        .Select(obj => obj.GetComponent<Weapon>())
        .ToList();
    }

    private void EvaluateActions()
    {
        if (enemyWeapon.Weapon == null)
        {
            UpdateState(EnemyState.FIND_WEAPON);
            return;
        }

        if (navMeshAI.Arrived && arenaCollider.PlayerOnTheRange)
        {
            UpdateState(EnemyState.STALK);
            return;
        }

        if (navMeshAI.Arrived && !arenaCollider.PlayerOnTheRange)
        {
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

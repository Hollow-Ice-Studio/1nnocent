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
    private const string 
        ARENA_TAG = "Arena",
        PLAYER_TAG = "Player";

    [Tooltip("Área do mapa em que o inimigo surge")]
    [SerializeField] private MapSection mapSection;
    private NavMeshAI navMeshAI;
    private EnemyStalkerAnimatorStateSwitcher animatorController;
    public EnemyWeaponAtHand enemyWeapon;
    private ArenaCollider arenaCollider;
    private GameObject playerObj;
    [SerializeField] private EnemyState currentState;
    public EnemyState CurrentState { get { return currentState; } }


    [SerializeField] private List<Weapon> availableWeapons;
    public List<Weapon> AvailableWeapons { get { return availableWeapons; } }
    private void Awake()
    {
        CheckComponents();
        navMeshAI.PlayerObj = playerObj;
        navMeshAI.Owner = this;
        animatorController.Owner = this;
    }

    void CheckComponents()
    {
        animatorController = GetComponentInChildren<EnemyStalkerAnimatorStateSwitcher>();
        if (animatorController == null)
            throw new MissingComponentException("Adicione um EnemyStalkerAnimatorController como componente deste objeto");

        navMeshAI = GetComponentInChildren<NavMeshAI>();
        if (navMeshAI == null)
            throw new MissingComponentException("Adicione um NavMeshAI como componente deste objeto");

        enemyWeapon = GetComponentInChildren<EnemyWeaponAtHand>();
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
        ScanWeapons();
        PublishState();
        EvaluateActions();
    }

    private void ScanWeapons()
    {
        /*
        Sugestão de melhoria:
        vocês poderiam criar uma classe MapArea que lista todos os objetos 
        dentro da area (inimigos, armas, etc) e transmite essas informações 
        para essas classes (esse método, por exemplo, poderia ser movido para MapArea e 
        distribuir a referencia da lista de armas para os inimigos)
        */
        availableWeapons = GameObject.FindGameObjectsWithTag("Weapon").ToList()
        .Where(obj =>
        {
            Weapon weapon = obj.GetComponent<Weapon>();
            return weapon != null && weapon.MapSection == mapSection;
        })
        .Select(obj => obj.GetComponent<Weapon>())
        .ToList();
    }

    private void EvaluateActions()
    {
        if (enemyWeapon.CurrentWeapon == null && availableWeapons.Count > 0)
        {
            UpdateState(EnemyState.FIND_WEAPON);
            return;
        }

        if (arenaCollider.PlayerOnTheRange)
        {
            UpdateState(EnemyState.STALK);
            return;
        }

        UpdateState(EnemyState.SCOUT);
        return;
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

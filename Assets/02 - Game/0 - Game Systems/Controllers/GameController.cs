using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace innocent
{
    public class GameController : MonoBehaviour
    {
        #region Const
        const string SYSTEMS_PATH = "GameSystems/";
        const string PlayerTag = "Player";
        #endregion

        #region Properties
        public Character character;
        protected List<IGameSystem> activeSystems { get; private set; }
        protected Dictionary<string, GameSystem> gameSystems = new Dictionary<string, GameSystem>();
        StateMachine _stateMachine;
        public StateMachine StateMachine{ get => _stateMachine = (_stateMachine ?? new StateMachine()); }
        Transform systemHolder;
        #endregion

        #region MonoBehaviour
        void Awake() => BuildGameSystems();
        void Start() => CacheSceneGameObjectsReferences();
        void Update() => ExecuteActiveSystemsLogicRoutine();
        void FixedUpdate() => ExecuteActiveSystemsPhysicsRoutine();
        #endregion

        #region Custom methods
        void BuildGameSystems()
        {
            systemHolder = GetComponent<Transform>();
            InstatiateAllGameSystems();
            //DisableAllGameSystems();
            StateMachine.Initialize(new IdleState(this, StateMachine));
        }
        void DisableAllGameSystems()
        {
            for (int i = 0; i < GetSystems().Count - 1; i++)
                GetSystems()[i].gameObject.SetActive(false);
        }

        void CacheSceneGameObjectsReferences()
        {
            character = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<Character>();
        }

        public List<GameSystem> GetSystems()
        {
            return gameSystems.Values.ToList();
        }

        void ExecuteActiveSystemsPhysicsRoutine()
        {
            activeSystems = new List<IGameSystem>(GetComponentsInChildren<IGameSystem>());
            foreach (IGameSystem system in activeSystems)
                system.PhysicsRoutine();
        }

        void ExecuteActiveSystemsLogicRoutine()
        {
            activeSystems = new List<IGameSystem>(GetComponentsInChildren<IGameSystem>());
            foreach (IGameSystem system in activeSystems)
                system.LogicRoutine();
        }

        #endregion

        #region StateMachine
        public void ChangeState(State newState)
        {
            StateMachine.ChangeState(newState);
        }

        public State GetCurrentState()
        {
            return StateMachine.GetCurrentState();
        }

        public bool CurrentStateIs<T>(T state)
        {
            return GetCurrentState().GetType().Equals(state);
        }

        #endregion
        public void InstatiateAllGameSystems()
        {
            
            Debug.Log($"{SYSTEMS_PATH}");
            Debug.Log(Resources.LoadAll<GameSystem>($"{SYSTEMS_PATH}").Length);
            foreach (var a in Resources.LoadAll<GameObject>($"{SYSTEMS_PATH}"))
            {
                try
                {
                    GameSystem gameSystem = GetComponentInChildren(a.GetComponent<GameSystem>().GetType()) as GameSystem;
                    if (gameSystem == null)
                    {
                        GameObject gameSystemObj = Instantiate(a, systemHolder);
                        gameSystem = gameSystemObj.GetComponent<GameSystem>();
                        gameObject.LogWithColor(gameSystem, "red");
                    }
                    this.LogSystemAdded(a.name);
                    gameSystems.Add(a.name, gameSystem);
                }
                catch(Exception ex)
                {
                    Debug.Log(ex);
                }
            }
        }
            

        public void InstantiateSystems<T>() where T : IGameSystem
        {
            try
            {
                GameSystem gameSystem = GetComponentInChildren<T>() as GameSystem;
                if (gameSystem == null)
                {
                    GameObject gameSystemObj = Instantiate(Resources.Load<GameObject>($"{SYSTEMS_PATH}{typeof(T).Name}"), systemHolder);
                    gameSystem = gameSystemObj.GetComponent<GameSystem>();
                }
                gameObject.LogSystemAdded(typeof(T).Name);
                gameSystems.Add(typeof(T).Name, gameSystem);
            }
            catch
            {
                throw new GameSystemInstantiationException(typeof(T).Name);
            }

        }

        public T GetSystem<T>() where T : GameSystem
        {
            var key = typeof(T).Name;
            return gameSystems.ContainsKey(key) ? (T)gameSystems[key] : default(T);
        }

    }
}


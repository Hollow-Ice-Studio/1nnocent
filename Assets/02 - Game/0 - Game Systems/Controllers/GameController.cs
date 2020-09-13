using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace panorama
{
    public class GameController : MonoBehaviour
    {

        #region Const
        private const string SYSTEMS_PATH = "Prefabs/Game Systems/";
        #endregion

        #region Properties
        public Character character { get; private set; }
        public Inventory inventory { get; private set; }
        protected List<IGameSystem> activeSystems { get; private set; }
        protected Dictionary<string, GameSystem> gameSystems = new Dictionary<string, GameSystem>();

        private StateMachine stateMachine;
        public StateMachine StateMachine
        {
            get
            {
                if (stateMachine == null)
                    stateMachine = new StateMachine();

                return stateMachine;
            }
        }

        private Transform systemHolder;
        #endregion

        #region MonoBehaviour
        void Awake()
        {
            systemHolder = GetComponentInChildren<Transform>();
            GameFactory.Create(this);

            for (int i = 0; i < GetSystems().Count - 1; i++)
            {
                GetSystems()[i].gameObject.SetActive(false);
            }

            character = (Character) FindObjectOfType(typeof(Character));//Mudar para findByTag
            inventory = GetComponentInChildren<Inventory>(true);
            StateMachine.Initialize(new IdleState(this, StateMachine));
        }

        private void Update()
        {
            activeSystems = new List<IGameSystem>(GetComponentsInChildren<IGameSystem>());

            foreach (IGameSystem system in activeSystems)
                system.LogicRoutine();
        }

        private void FixedUpdate()
        {
            activeSystems = new List<IGameSystem>(GetComponentsInChildren<IGameSystem>());

            foreach (IGameSystem system in activeSystems)
                system.PhysicsRoutine();
        }

        public void InstantiateSystems<T>() where T : IGameSystem
        {
            GameSystem gameSystem = GetComponentInChildren<T>() as GameSystem;

            if (gameSystem == null)
            {
                GameObject gameSystemObj = Instantiate(Resources.Load<GameObject>($"{SYSTEMS_PATH}{typeof(T).Name}"), systemHolder);
                gameSystem = gameSystemObj.GetComponent<GameSystem>();
            }
            Debug.Log($"Add System: {typeof(T).Name}");
            gameSystems.Add(typeof(T).Name, gameSystem);
        }

        public T GetSystem<T>() where T : GameSystem
        {
            var key = typeof(T).Name;
            return gameSystems.ContainsKey(key) ? (T)gameSystems[key] : default(T);
        }

        public List<GameSystem> GetSystems()
        {
            return gameSystems.Values.ToList();
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

        public static class GameFactory
        {
            public static void Create(GameController gameController)
            {
                gameController.InstantiateSystems<CharacterAnimationSystem>();
                gameController.InstantiateSystems<CharacterMovementSystem>();
                gameController.InstantiateSystems<CollectableSystem>();
            }
        }
    }
}


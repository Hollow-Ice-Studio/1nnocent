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
        public const string SYSTEMS_PATH = "GameSystems/";
        public const string PlayerTag = "Player";
        #endregion

        #region Properties
        protected List<IGameSystem> activeSystems { get; private set; }
        protected Dictionary<string, GameSystem> gameSystems = new Dictionary<string, GameSystem>();
        Transform systemHolder;
        #endregion

        #region MonoBehaviour
        void Awake() => BuildGameSystems();
        void Reset() => BuildGameSystems();
        void Update() => ExecuteActiveSystemsLogicRoutine();
        void FixedUpdate() => ExecuteActiveSystemsPhysicsRoutine();
        #endregion

        #region Custom methods
        void BuildGameSystems()
        {
            systemHolder = GetComponent<Transform>();
            InstatiateAllGameSystems();
        }

        void DisableAllGameSystems()
        {
            for (int i = 0; i < GetSystems().Count - 1; i++)
                GetSystems()[i].gameObject.SetActive(false);
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

        public void InstatiateAllGameSystems()
        {
            this.LogWithColor($"{nameof(SYSTEMS_PATH)}: {SYSTEMS_PATH}","green");
            this.LogWithColor($"Quantidade de gamesystems: {Resources.LoadAll<GameSystem>($"{SYSTEMS_PATH}").Length} ","green");
            foreach (var gameObjectFoundInTheFolder in Resources.LoadAll<GameObject>($"{SYSTEMS_PATH}"))
            {
                try
                {
                    GameSystem gameSystem = GetComponentInChildren(gameObjectFoundInTheFolder.GetComponent<GameSystem>().GetType()) as GameSystem;
                    if (gameSystem == null)
                    {
                        GameObject gameSystemObj = DynamicAssets.Instantiate(gameObjectFoundInTheFolder, systemHolder);
                        gameSystem = gameSystemObj.GetComponent<GameSystem>();
                        gameObject.LogWithColor(gameSystem, "red");
                    }
                    this.LogSystemAdded(gameObjectFoundInTheFolder.name);
                    gameSystems.Add(gameObjectFoundInTheFolder.name, gameSystem);
                }
                catch(Exception ex)
                {
                    Debug.Log(ex);
                }
            }
        }

    }
}


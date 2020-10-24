using UnityEngine;

namespace innocent
{
    public abstract class GameSystem : MonoBehaviour, IGameSystem
    {
        protected GameController gameController;

        public GameController GameController { get; set; }

        protected virtual void Awake()
        {
            gameController = GetComponentInParent<GameController>();
        }

        public virtual void LogicRoutine()
        {
            
        }

        public virtual void PhysicsRoutine()
        {
            
        }

    }
}


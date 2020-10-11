using onennocent;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace onennocent
{
    public class CharacterMovementSystem : GameSystem
    {
        #region Properties
        string NotificationName;
        #region Serializable Fields
        [Header("Character speed in unit per second")]
        // [Valores de referência] Caminhada:  1.3m/s; Trotar: > 1.6m/s; Correr: > 2.6m/s
        [SerializeField]
        [Range(0, 10)]
        float walkSpeed = 1.5f;
        [SerializeField]
        [Range(0, 10)]
        float runSpeed = 2.7f;
        [SerializeField]
        [Range(0, 10)]
        float crawlingSpeed = 0.8f;
        #endregion
        #endregion

        #region MonoBehaviour
        void Start()
        {
            CacheReferences();
        }
        private void OnEnable()
        {
            AddObservers();
        }
        void OnDisable()
        {
            RemoveObservers();
        }
        #endregion

        #region IGameSystem

        public override void PhysicsRoutine()
        {
            Move();
        }

        public override void LogicRoutine()
        {
            UpdateSpeedModeBasedOnInput();
            UpdateDirection();
        }
        #endregion

        #region Notification Handler
        void ActionOnNotification(object sender, object args)
        {
            
        }
        #endregion

        #region CustomMethods
        void AddObservers()
        {
            this.AddObserver(ActionOnNotification, NotificationName);
        }
        void RemoveObservers()
        {
            this.RemoveObserver(ActionOnNotification, NotificationName);
        }
        void CacheReferences()
        {
            
        }
        void UpdateSpeedModeBasedOnInput()
        {
            
        }
        void UpdateDirection()
        {
            
        }

        void Move()
        {
            
        }
        #endregion
    }
}


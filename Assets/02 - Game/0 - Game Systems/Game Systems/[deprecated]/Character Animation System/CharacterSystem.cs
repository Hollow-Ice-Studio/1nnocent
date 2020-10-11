using onennocent;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace onennocent
{
    public class CharacterSystem : GameSystem
    {
        #region Properties
        Character character;
        #region Const
        private const string MouseLeftNotification = Notification.MOUSE_LEFT_INPUT_NOTIFICATION;
        #endregion
        #region Serializable Fields

        #endregion
        #endregion

        #region MonoBehaviour
        void Start()
        {
            Build();
        }

        void OnEnable()
        {
            this.AddObserver(handleCharacterDataOnNotification, "Notification");
        }

        void OnDisable()
        {
            this.RemoveObserver(handleCharacterDataOnNotification, "Notification");
        }
        #endregion

        #region IGameSystem

        public override void PhysicsRoutine()
        {
            Move();
        }

        public override void LogicRoutine()
        {
            HandleInput();
        }
        #endregion
        
        #region Notification Handler
        void handleCharacterDataOnNotification(object sender, object args)
        {
            GetComponent<Animator>().SetTrigger(args as string);
        }
        #endregion
        
        #region CustomMethods
        void Build()
        {
            
        }
        void Move()
        {

        }
        void HandleInput()
        {

        }
        #endregion
    }
}


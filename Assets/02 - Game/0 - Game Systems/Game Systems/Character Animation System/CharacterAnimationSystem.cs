using onennocent;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace onennocent
{
    public class CharacterAnimationSystem : GameSystem
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
            this.AddObserver(TriggerAnimationOnNotification, "Notification");
            this.AddObserver(SetBoolTransitionOnNotification, "Notification");
        }

        void OnDisable()
        {
            this.RemoveObserver(SetBoolTransitionOnNotification, "Notification");
            this.RemoveObserver(SetBoolTransitionOnNotification, "Notification");
        }
        #endregion

        #region IGameSystem

        public override void PhysicsRoutine()
        {
            Animate();
        }

        public override void LogicRoutine()
        {
            DecideAnimationExecution();
        }
        #endregion
        
        #region Notification Handler
        void TriggerAnimationOnNotification(object sender, object args)
        {
            GetComponent<Animator>().SetTrigger(args as string);
        }
        void SetBoolTransitionOnNotification(object sender, object args)
        {
            GetComponent<Animator>().SetBool(args as string,true);
        }

        void PlayAnimationOnNotification(object sender, object args)
        {
            GetComponent<Animator>().Play(args as string, 0);
        }
        #endregion
        #region CustomMethods
        private void Build()
        {
            
        }
        
        void Animate()
        {
            
        }
        void DecideAnimationExecution()
        {
           
        }
        #endregion
    }
}


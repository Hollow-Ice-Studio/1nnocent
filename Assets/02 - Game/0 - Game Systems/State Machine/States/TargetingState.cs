using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class TargetingState : State
    {

        #region Constructor
        public TargetingState(GameController gameController, StateMachine stateMachine) : base(gameController, stateMachine) { }
        #endregion

        #region State Methods
        public override void Enter()
        {
            base.Enter();
            //gameController.GetSystem<TargetingSystem>().gameObject.SetActive(true);
            this.AddObserver(OnTargetingMode, Notification.MOUSE_RIGHT_INPUT_NOTIFICATION);
        }




        public override void Exit()
        {
            base.Exit();
            //gameController.GetSystem<TargetingSystem>().gameObject.SetActive(false);
            this.RemoveObserver(OnTargetingMode, Notification.MOUSE_RIGHT_INPUT_NOTIFICATION);
        }

        void OnTargetingMode(object sender, object args)
        {
            gameController.ChangeState(new IdleState(gameController, stateMachine));
        }
        #endregion
    }
}


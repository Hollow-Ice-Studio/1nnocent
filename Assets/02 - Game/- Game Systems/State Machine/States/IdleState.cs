using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class IdleState : State
    {
        #region Constructor
        public IdleState(GameController gameController, StateMachine stateMachine) : base(gameController, stateMachine) { }
        #endregion

        #region State Methods
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
        #endregion

        #region Notification Handlers

        #endregion
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onennocent
{
    public abstract class State
    {
        #region Properties
        protected GameController gameController;
        protected StateMachine stateMachine;
        #endregion

        #region Constructor
        protected State(GameController gameController, StateMachine stateMachine)
        {
            this.gameController = gameController;
            this.stateMachine = stateMachine;
        }
        #endregion

        #region State Methods
        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }
        #endregion
    }
}



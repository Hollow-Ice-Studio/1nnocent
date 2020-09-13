using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace panorama
{
    public class DialogueState : State
    {
        #region Constructor
        public DialogueState(GameController gameController, StateMachine stateMachine) : base(gameController, stateMachine) { }
        #endregion

        #region State Methods
        public override void Enter()
        {
            base.Enter();
            //gameController.GetSystem<DialogueSystem>()?.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();
            //gameController.GetSystem<DialogueSystem>()?.gameObject.SetActive(false);
        }
        #endregion
    }
}


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
            gameController.GetSystem<CharacterMovementSystem>()?.gameObject.SetActive(true);
            gameController.GetSystem<CharacterAnimationSystem>()?.gameObject.SetActive(true);
            //gameController.GetSystem<DialogueSystem>()?.gameObject.SetActive(true);
            this.AddObserver(OnTargetingMode, Notification.MOUSE_RIGHT_INPUT_NOTIFICATION);
            this.AddObserver(OnInventory, Notification.INVENTORY_INPUT_NOTIFICATION);
        }

        public override void Exit()
        {
            base.Exit();
            gameController.GetSystem<CharacterMovementSystem>()?.gameObject.SetActive(false);
            gameController.GetSystem<CharacterAnimationSystem>()?.gameObject.SetActive(false);
            //gameController.GetSystem<DialogueSystem>()?.gameObject.SetActive(false);
            this.RemoveObserver(OnTargetingMode, Notification.MOUSE_RIGHT_INPUT_NOTIFICATION);
            this.RemoveObserver(OnInventory, Notification.INVENTORY_INPUT_NOTIFICATION);
        }
        #endregion

        #region Notification Handlers
        void OnTargetingMode(object sender, object args)
        {
            gameController.ChangeState(new TargetingState(gameController, stateMachine));
        }

        void OnInventory(object sender, object args)
        {
            gameController.ChangeState(new InventoryState(gameController, stateMachine));
        }
        #endregion
    }
}


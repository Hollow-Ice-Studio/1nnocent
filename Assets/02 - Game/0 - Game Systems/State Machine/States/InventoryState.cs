using TheLiquidFire.Notifications;

namespace onennocent
{
    public class InventoryState : State
    {

        #region Constructor
        public InventoryState(GameController gameController, StateMachine stateMachine) : base(gameController, stateMachine) { }
        #endregion

        #region State Methods
        public override void Enter()
        {
            base.Enter();
            //gameController.GetSystem<InventorySystem>()?.gameObject.SetActive(true);
            this.AddObserver(OnInventoryInput, Notification.INVENTORY_INPUT_NOTIFICATION);
            this.PostNotification(Notification.ENTER_INVENTORY_STATE_NOTIFICATION);
        }

        public override void Exit()
        {
            base.Exit();
            //gameController.GetSystem<InventorySystem>()?.gameObject.SetActive(false);
            this.RemoveObserver(OnInventoryInput, Notification.INVENTORY_INPUT_NOTIFICATION);
            this.PostNotification(Notification.EXIT_INVENTORY_STATE_NOTIFICATION);
        }
        #endregion

        #region Notification Handlers
        void OnInventoryInput(object sender, object args)
        {
            gameController.ChangeState(new IdleState(gameController, stateMachine));
        }
        #endregion
    }
}


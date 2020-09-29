

namespace onennocent
{
    public static class Notification
    {
        // State Machine
        public const string ENTER_INVENTORY_STATE_NOTIFICATION = "StateNotification.OpenInventory";
        public const string EXIT_INVENTORY_STATE_NOTIFICATION  = "StateNotificaiton.CloseInventory";
        public const string START_DIALOGUE = "DialogueNotification.StartDialogue";
        public const string TRY_DIALOGUE = "DialogueSystemNotification.TryDialogue";
        public const string INVENTORY_HOLD_ITEM = "InventoryNotification.HoldItem";
        public const string INVENTORY_ADDED_ITEM = "InventoryNotification.AddedItem";
        public const string ITEM_ADDED = "ItemNotification.AddItem";
        public const string TRY_COLLECT = "CollectableSystemNotification.TryCollect";

        // Input Controller
        public const string INVENTORY_INPUT_NOTIFICATION = "InputNotification.Inventory";
        public const string MOUSE_RIGHT_INPUT_NOTIFICATION = "InputNotification.MouseRight";
        public const string MOUSE_LEFT_INPUT_NOTIFICATION = "InputNotification.MouseLeft";
        public const string DIALOGUE_INPUT_NOTIFICATION =  "InputNotification.Confirm";
    }
}


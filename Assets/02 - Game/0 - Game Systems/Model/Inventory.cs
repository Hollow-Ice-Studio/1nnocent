using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TheLiquidFire.Notifications;

namespace onennocent
{
    public class Inventory : MonoBehaviour
    {
        #region Const
        private const string AddItemNotification = Notification.ITEM_ADDED;
        #endregion

        #region Properties
        #endregion

        #region MonoBehaviour
        void Start()
        {
            //this.AddObserver(OnAddItem, AddItemNotification);
        }
        #endregion
    }
}


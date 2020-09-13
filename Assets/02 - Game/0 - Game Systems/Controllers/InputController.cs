using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace panorama
{
    public class InputController : MonoBehaviour
    {

        [SerializeField] private static readonly string[] buttons = 
            {"MouseLeft", "MouseRight", "Run", "Crouch", "Cancel", "Inventory", "Confirm"};

        void Update()
        {
            for (int i = 0; i < buttons.Length; ++i)
                if (Input.GetButtonUp(buttons[i]))
                {
                    this.PostNotification("InputNotification." + buttons[i]);
                }
        }
    }
}


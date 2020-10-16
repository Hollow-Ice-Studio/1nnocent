using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class InputController : MonoBehaviour
    {

        [SerializeField] private static readonly string[] buttons = 
            {ConfiguredButtonNames.SHOOT};

        void Update()
        {
            for (int i = 0; i < buttons.Length; ++i)
                if (Input.GetButtonUp(buttons[i]))
                {
                    Debug.Log("InputNotification." + buttons[i]);
                    this.PostNotification("InputNotification." + buttons[i]);
                }
        }
    }
}


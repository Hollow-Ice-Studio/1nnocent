using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public class AdamGroundMovementController : MonoBehaviour
    {
        Adam adam;
        private void Start() => adam = GetComponent<Adam>();
        void Update() => PlayerMovement();
        void PlayerMovement()
        {

            float z_move = Input.GetAxis(ConfiguredButtonNames.VerticalAxisName);
            float x_move = Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName);

            Vector3 vect3 = Vector3.ClampMagnitude(
                (transform.forward * z_move) + (transform.right * x_move)
                , 1);

            adam.velocity = (vect3 * adam.speed);
            if (adam.animator.GetBool("isRunning"))
                adam.rig.velocity = adam.velocity * adam.runningSpeed + new Vector3(0, adam.rig.velocity.y, 0);
            else
                adam.rig.velocity = adam.velocity + new Vector3(0, adam.rig.velocity.y, 0);
        }
    }
}

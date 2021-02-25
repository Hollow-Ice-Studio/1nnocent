using UnityEngine;

namespace innocent
{
    [RequireComponent(typeof(Rigidbody))]
    public class AdamMovementController : MonoBehaviour
    {
        #region Properties
        Adam adam;
        #endregion

        #region Mono Behaviour
        void Start() => Build();

        void Update()
        {
            AppointGrounded();
            PlayerMovement();
            Debug.DrawRay(transform.position + (transform.up * adam.beamdistance), -transform.up * adam.beamdistance * 2, Color.red);
        }
        #endregion

        void Build()
        {
            adam = GetComponent<Adam>();
        }

        void PlayerMovement()
        {
            float z_move = Input.GetAxis(ConfiguredButtonNames.VerticalAxisName);
            float x_move = Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName);

            Vector3 vect3 = Vector3.ClampMagnitude(
                (transform.forward * z_move) + (transform.right * x_move)
                , 1);

            adam.velocity = (vect3 * adam.speed);
            if (adam.animator.GetBool("isRunning"))
                adam.rig.velocity = adam.velocity * adam.runningSpeed + new Vector3(0, adam.rig.velocity.y,0);
            else
                adam.rig.velocity = adam.velocity + new Vector3(0, adam.rig.velocity.y,0);
        }



        //Esse método é ativado a partir da animação de pulo
        private void PlayerJumpTriggeredByAnimation()
        {
            //nao necessita de getKey no método de pulo se estiver ativando via animação
            if (adam.IsGrounded)
            {
                var forceDirection = Vector3.up * Mathf.Sqrt(adam.jumpHeight * -2f * Physics.gravity.y);
                Debug.Log(forceDirection);
                adam.rig.AddForce(forceDirection, ForceMode.VelocityChange);
            }
        }

        private void AppointGrounded()
        {
            var origin = transform.position + (transform.up * adam.beamdistance);
            if (Physics.Raycast(
                    origin, -transform.up, adam.beamdistance * 2))
                adam.IsGrounded = true;
            else
                adam.IsGrounded = false;
        }
    }
}
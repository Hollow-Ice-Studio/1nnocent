using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace innocent
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonCharacterController : MonoBehaviour
    {
        #region Properties
        public float
            speed = 1,
            jumpHeight = 1;
        public bool IsGrounded;
        float beamdistance;
        Rigidbody rig;
        #endregion

        #region Mono Behaviour
        void Start() => Build();

        void Update()
        {
            AppointGrounded();
            PlayerMovement();
            Debug.DrawRay(transform.position + (transform.up * beamdistance), -transform.up * beamdistance * 2, Color.red);
        }
        #endregion

        void Build()
        {
            rig = GetComponent<Rigidbody>();
            beamdistance = transform.localScale.y + .2f;
        }
        void PlayerMovement()
        {
            float z_move = Input.GetAxis(ConfiguredButtonNames.VerticalAxisName);
            float x_move = Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName);
            Vector3 vect3 = new Vector3(x_move, 0f, z_move);
            vect3.Normalize();
            if (Input.GetButton(ConfiguredButtonNames.RUN))
            {
                transform.Translate(vect3 * Time.deltaTime * speed * 2, Space.Self);
            }
            else
            {
                transform.Translate(vect3 * Time.deltaTime * speed, Space.Self);
            }

        }

        //Esse método é ativado a partir da animação de pulo
        private void PlayerJumpTriggeredByAnimation()
        {
            //nao necessita de getKey no método de pulo se estiver ativando via animação
            if (IsGrounded)
            {
                var forceDirection = Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                Debug.Log(forceDirection);
                rig.AddForce(forceDirection, ForceMode.VelocityChange);
            }
        }

        private void AppointGrounded()
        {
            var origin = transform.position + (transform.up * beamdistance);
            if (Physics.Raycast(
                    origin, -transform.up, beamdistance * 2))
                IsGrounded = true;
            else
                IsGrounded = false;
        }
    }
}
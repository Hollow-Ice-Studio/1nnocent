using UnityEngine;

namespace innocent
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonCharacterController : MonoBehaviour
    {
        #region Properties
        public float
            speed = 1,
            runningSpeed = 4,
            jumpHeight = 1;
        public bool IsGrounded;
        private Vector3 velocity;
        float beamdistance;
        Rigidbody rig;
        Animator animator;
        [HideInInspector]
        public float
            initialSpeed = 1,
            initialJumpHeight = 1;
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
            animator = GetComponent<Animator>();
            this.transform.rotation = Quaternion.identity;
            initialSpeed = speed;
            initialJumpHeight = jumpHeight;
        }

        void PlayerMovement()
        {
            float z_move = Input.GetAxis(ConfiguredButtonNames.VerticalAxisName);
            float x_move = Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName);

            Vector3 vect3 = Vector3.ClampMagnitude(
                (transform.forward * z_move) + (transform.right * x_move)
                , 1);

            velocity = (vect3 * speed);
            if (animator.GetBool("isRunning"))
                rig.velocity = velocity*runningSpeed + new Vector3(0, rig.velocity.y,0);
            else
                rig.velocity = velocity + new Vector3(0, rig.velocity.y,0);
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
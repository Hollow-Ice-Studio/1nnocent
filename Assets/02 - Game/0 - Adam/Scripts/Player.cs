using UnityEngine;

namespace innocent {
    [RequireComponent(typeof(CharacterController),typeof(Animator))]
    public class Player : MonoBehaviour
    {
        CharacterController characterController;
        Animator animator;
        public Vector3 rotation, moveDirection;
        public bool isGrounded;
        public float
            speed = 2,
            jumpHeight = 5,
            gravity = 9.8f;

        void Start() => Build();

        void Update() => Move();

        void Build()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        void Move()
        {
            isGrounded = characterController.isGrounded;
            float z_move = Input.GetAxis(ConfiguredButtonNames.VerticalAxisName);
            float x_move = Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName);
            moveDirection = new Vector3(x_move, 0, z_move);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * speed;
            if (isGrounded && Input.GetButton("Jump"))
            {
                Debug.Log("JUMP");
                moveDirection.y = jumpHeight;
            }

            moveDirection.y -= gravity; //* Time.deltaTime;
            moveDirection = transform.TransformDirection(moveDirection);
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}

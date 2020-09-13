using panorama;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace panorama
{
    public class CharacterMovementSystem : GameSystem
    {
        #region Properties
        Character character;
        float horizontalSpeed;
        float characterHorizontalScale;
        #endregion

        #region Serializable Fields
        [Header("Character speed in unit per second")]
        // [Valores de referência] Caminhada:  1.3m/s; Trotar: > 1.6m/s; Correr: > 2.6m/s
        [SerializeField]
        [Range(0, 10)] 
        float walkSpeed = 1.5f;
        [SerializeField]
        [Range(0, 10)]
        float runSpeed = 2.7f;
        [SerializeField]
        [Range(0, 10)]
        float crawlingSpeed = 0.8f;
        #endregion

        #region MonoBehaviour
        void Start()
        {
            character = gameController.character;
            characterHorizontalScale = character.transform.lossyScale.x;
        }
        #endregion

        #region IGameSystem

        public override void PhysicsRoutine()
        {
            Move();
        }

        public override void LogicRoutine()
        {
            UpdateSpeed();
            UpdateDirection();
        }
        #endregion

        #region CustomMethods
        void UpdateSpeed()
        {
            horizontalSpeed = Input.GetButton("Run") ? runSpeed :
                                (Input.GetButton("Crouch") ? crawlingSpeed : walkSpeed);
            horizontalSpeed *= characterHorizontalScale;
        }
        void UpdateDirection()
        {
            float moveX = Input.GetAxis("Horizontal");
            horizontalSpeed *= moveX;
        }

        void Move()
        {
            character.Rb2d.velocity = new Vector2(horizontalSpeed, 0);
        }
        #endregion
    }
}


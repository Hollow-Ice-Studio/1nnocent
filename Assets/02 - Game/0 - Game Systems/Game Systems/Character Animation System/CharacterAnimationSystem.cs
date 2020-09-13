using panorama;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace panorama
{
    public class CharacterAnimationSystem : GameSystem
    {
        #region Properties
        Character character;
        Rigidbody2D rigid;
        Animator movementAnimator;
        #endregion

        #region Serializable Fields
        //TODO: 
        #endregion

        #region MonoBehaviour
        void Start()
        {
            character = gameController.character;
            rigid = character.Rb2d;
            movementAnimator = character.characterAnimator;
        }
        #endregion

        #region IGameSystem

        public override void PhysicsRoutine()
        {
            Animate();
        }

        public override void LogicRoutine()
        {
            if (Input.GetButton("Run"))
                movementAnimator.SetBool("isCrouching", false);
            else if (Input.GetButton("Crouch"))
                movementAnimator.SetBool("isCrouching", true);
            else
                movementAnimator.SetBool("isCrouching", false);
        }
        #endregion

        #region CustomMethods
        void Animate()
        {
            movementAnimator.SetFloat("HorizontalVelocity", rigid.velocity.x);
            movementAnimator.SetFloat("VerticalVelocity", rigid.velocity.y);
            bool isWalking = Mathf.Abs(rigid.velocity.x) > 0;
            movementAnimator.SetBool("isWalking", isWalking);
            bool isRunning = Mathf.Abs(rigid.velocity.x) > 2;
            movementAnimator.SetBool("isRunning", isRunning);
            if (rigid.velocity.x > 0.5)
                character.FlipSpriteDirection(true);
            else if (rigid.velocity.x < -0.5)
                character.FlipSpriteDirection(false);
        }

        #endregion
    }
}


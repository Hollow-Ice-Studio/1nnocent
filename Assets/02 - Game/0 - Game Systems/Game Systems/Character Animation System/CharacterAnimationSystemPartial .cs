using innocent;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public enum AdamAnimationState
    {

    }
    public partial class CharacterAnimationSystem : GameSystem
    {
        #region Delegates
        delegate void AnimationExecutorDelegate();
        AnimationExecutorDelegate animationExecutorDelegate;
        #endregion
        #region Properties
        ThirdPersonCharacterController thirdPersonCharacter;
        Animator animator;

        public AnimationActivator[] animationActivators;
        Transform aimRotation;
        string buttonNameToShoot = ConfiguredButtonNames.SHOOT;
        float lastJumpTimeInSeconds;
        #endregion
        #region constants
        const string 
            EnemyTag = "enemy",
            AgonyLayerName = "Agony",
            PistolLayerName = "Pistol Layer",
            JumpTriggerName = "Jump",
            ShootTriggerName = "Shoot";
        #endregion

        #region Mono Behaviour
        void CacheReferences()
        {
            var character = gameController.character;
            aimRotation = character.TargetRotationTransform;
            lastJumpTimeInSeconds = Time.time;
            animator = character.GetComponent<Animator>();
            thirdPersonCharacter = gameController.character.GetComponent<ThirdPersonCharacterController>();
            AnimationActivator.animator = animator;
            foreach (var animationActivator in animationActivators)
                if(animationActivator!=null)
                    animationExecutorDelegate += animationActivator.Activation;
        }

        void DoSomethingOnCollision(Collision collision)
        {
            if (collision.gameObject.tag == EnemyTag)
            {
                //TriggerAnimationWithEvent("isDead", true);
            }
        }
        #endregion

        #region IGameSystem
        void ExecutionPerFrame()
        {
            Aim();
            //Shoot();
            CheckIfTheCharacterIsOnTheGround();
            Jump();
            ExecuteConfiguredAnimations();
        }
        #endregion

        void CheckIfTheCharacterIsOnTheGround()
        {
            //mudar pra play, o fluxo deve simplesmente pular pra OnAir se não esta em contato com o chão
            animator?.SetBool("isOnGround", thirdPersonCharacter.IsGrounded);
        }

        void Aim()
        {
            //posso transformar em um delegate talvés
            animator?.SetFloat("MouseY", (aimRotation.localRotation.x) * -100);
            animator?.SetFloat("HorizontalInput", Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName));
            animator?.SetFloat("VerticalInput", Input.GetAxis(ConfiguredButtonNames.VerticalAxisName));
        }

        void Shoot()
        {
            if (Input.GetButtonDown(buttonNameToShoot))
                animator?.SetTrigger(ShootTriggerName);
        }

        void ExecuteConfiguredAnimations()
        {
            animationExecutorDelegate?.Invoke();
        }

        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) 
                && thirdPersonCharacter.IsGrounded 
                && Time.time > (lastJumpTimeInSeconds + 1f))
            {
                lastJumpTimeInSeconds = Time.time;
                animator?.SetTrigger(JumpTriggerName);
            }
        }

        bool IsRunning()
        {
            return IsWalking() && Input.GetKey(KeyCode.LeftShift);
        }

        bool IsWalking()
        {
            return 
                (Input.GetAxis(ConfiguredButtonNames.HorizontalAxisName) != 0 
                || Input.GetAxis(ConfiguredButtonNames.VerticalAxisName) != 0);
        }

        public void IncreaseAgonyLevelOnAnimationActivation()
        {
            if (animator.GetLayerWeight(animator.GetLayerIndex(PistolLayerName)) == 1)
            {
                int agonyLayerIndex = animator.GetLayerIndex(AgonyLayerName);
                float actualLevel = animator.GetLayerWeight(agonyLayerIndex);
                if (actualLevel >= 0.1f)
                {
                    actualLevel = 1;
                    StartCoroutine(ReduceInsanity(1f));
                }
                else
                {
                    actualLevel += 0.01f;
                }
                animator.SetLayerWeight(agonyLayerIndex, actualLevel);
            }
        }

        private IEnumerator ReduceInsanity(float waitTime)
        {
            int agonyLayerIndex = animator.GetLayerIndex(AgonyLayerName);
            for (int i = 0; i <= 5; i++)
            {
                float actualLevel = animator.GetLayerWeight(agonyLayerIndex);
                actualLevel -= 0.2f;
                if (actualLevel <= 0)
                    actualLevel = 0.01f;
                animator.SetLayerWeight(agonyLayerIndex, actualLevel);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}


using System.Collections;
using UnityEngine;

namespace innocent
{
    public class ThirdPersonAnimationController : MonoBehaviour
    {
        #region Properties
        //Delegates
        delegate void AnimationExecutorDelegate();
        AnimationExecutorDelegate animationExecutorDelegate;
        //Constants
        const string
            EnemyTag = "enemy",
            AgonyLayerName = "Agony",
            PistolLayerName = "Pistol Layer",
            JumpTriggerName = "Jump",
            ShootTriggerName = "Shoot";
        //private
        Adam adam;
        Animator animator;
        //public
        public AnimationActivator[] animationActivators;
        Transform aimRotation;
        string buttonNameToShoot = ConfiguredButtonNames.SHOOT;
        float lastJumpTimeInSeconds;
        #endregion

        #region MonoBehaviour Event Functions
        void Reset() => CacheReferences();
        void Start() => CacheReferences();
        void Update() => ExecutionPerFrame();
        void OnCollisionEnter(Collision collision) => DoSomethingOnCollision(collision);
        #endregion

        #region Start
        void CacheReferences()
        {
            var character = GetComponent<Adam>();
            aimRotation = character.TargetRotationTransform;
            lastJumpTimeInSeconds = Time.time;
            animator = character.GetComponent<Animator>();
            adam = character.GetComponent<Adam>();
            AnimationActivator.animator = animator;
            foreach (var animationActivator in animationActivators)
                if (animationActivator != null)
                    animationExecutorDelegate += animationActivator.Activation;
        }
        #endregion

        #region Update
        void ExecutionPerFrame()
        {
            Aim();
            Shoot();
            CheckIfTheCharacterIsOnTheGround();
            Jump();
            ExecuteConfiguredAnimations();
        }
        #endregion

        #region On Collision
        void DoSomethingOnCollision(Collision collision)
        {
            if (collision.gameObject.tag == EnemyTag)
            {
                //TriggerAnimationWithEvent("isDead", true);
            }
        }
        #endregion

        #region Custom methods
        void CheckIfTheCharacterIsOnTheGround()
        {
            //mudar pra play, o fluxo deve simplesmente pular pra OnAir se não esta em contato com o chão
            animator?.SetBool("isOnGround", adam.IsGrounded);
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
                && adam.IsGrounded
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
     
        public void IncreaseAgonyLevelOnAnimationActivation(bool toMaximum=false)
        {
            if (animator.GetLayerWeight(animator.GetLayerIndex(PistolLayerName)) == 1)
            {
                int agonyLayerIndex = animator.GetLayerIndex(AgonyLayerName);
                float actualLevel = animator.GetLayerWeight(agonyLayerIndex);
                if (toMaximum)
                    actualLevel = 2f;
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
            var adam = this.GetComponent<Adam>();
            int agonyLayerIndex = animator.GetLayerIndex(AgonyLayerName);
            adam.speed = 0.5f;
            adam.jumpHeight = 0.5f;
            yield return new WaitForSeconds(12);
            for (int i = 0; i <= 5; i++)
            {
                float actualLevel = animator.GetLayerWeight(agonyLayerIndex);
                actualLevel -= 0.2f;
                if (actualLevel <= 0)
                    actualLevel = 0.01f;
                animator.SetLayerWeight(agonyLayerIndex, actualLevel);
                yield return new WaitForSeconds(waitTime);
            }
            adam.speed = adam.initialSpeed;
            adam.jumpHeight = adam.initialJumpHeight;
        }
        #endregion
    }
}

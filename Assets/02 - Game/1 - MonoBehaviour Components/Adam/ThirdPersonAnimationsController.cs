using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationsTriggers
{
    [SerializeField]
    public KeyCode eventTriggerKey;
    [SerializeField]
    public string animationName;
}
[RequireComponent(typeof(Animator))]
public class ThirdPersonAnimationsController : MonoBehaviour
{
    public AnimationsTriggers[] animationsTriggers;
    [SerializeField]
    public Transform aimRotation;
    Animator animator;
    ThirdPersonCharacterController thirdPersonCharacter;
    float t;


    void Start()
    {
        t = Time.time;
        animator = GetComponent<Animator>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacterController>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
        }
        for (int i=0;i< animationsTriggers.Length; i++)
        {
            TriggerAnimationWithEvent(animationsTriggers[i].animationName, animationsTriggers[i].eventTriggerKey);
        }
        if (Input.GetKeyDown(KeyCode.Space) && thirdPersonCharacter.isgrounded && Time.time>(t+1f))
        {
            t = Time.time;
            animator.SetTrigger("Jump");
        }
        animator.SetFloat("MouseY", (aimRotation.localRotation.x) * -100);
        animator.SetFloat("HorizontalInput",Input.GetAxis("Horizontal"));
        animator.SetFloat("VerticalInput", Input.GetAxis("Vertical"));
        animator.SetBool("isOnGround", thirdPersonCharacter.isgrounded);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //TriggerAnimationWithEvent("isDead", true);
        }
    }

    bool IsRunning()
    {
        return IsWalking() && Input.GetKey(KeyCode.LeftShift);
    }
    bool IsWalking()
    {
        return (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
    }
    public void TriggerAnimationWithEvent(string animationName,bool triggerEvent)
    {
        if (triggerEvent)
        {
            animator.SetBool(animationName, true);
        }
        else
        {
            animator.SetBool(animationName, false);
        }
    }
    void TriggerAnimationWithEvent(string animationName, KeyCode triggerEvent)
    {
        if (Input.GetKey(triggerEvent))
        {
            animator.SetBool(animationName, true);
        }
        else
        {
            animator.SetBool(animationName, false);
        }
    }
    public void IncreaseAgonyLevel()
    {
        if (animator.GetLayerWeight(animator.GetLayerIndex("Pistol Layer")) == 1)
        {
            int agonyLayerIndex = animator.GetLayerIndex("Agony");
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
        int agonyLayerIndex = animator.GetLayerIndex("Agony");
        for(int i=0; i <= 5; i++)
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


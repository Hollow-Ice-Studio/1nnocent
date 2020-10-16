using UnityEngine;
using UnityEditor;

namespace innocent
{
    public enum AnimationActivationMode
    {
        SET_BOOL,
        SET_FLOAT,
        SET_TRIGGER
    }
    [CreateAssetMenu(fileName = "AnimationActivator", menuName = "Onennocent/AnimationActivator", order = 1)]
    public class AnimationActivator : ScriptableObject
    {
        public static Animator animator;

        public AnimationActivationMode mode;
        public string paramName;
        public bool boolParam;
        public float floatParam;
        public KeyCode activationKeyboardCode;

        public void Activation()
        {
            if (Input.GetKeyDown(activationKeyboardCode))
            {
                switch (mode)
                {
                    case AnimationActivationMode.SET_BOOL:
                        animator?.SetBool(paramName, boolParam);
                        break;
                    case AnimationActivationMode.SET_FLOAT:
                        animator?.SetFloat(paramName, floatParam);
                        break;
                    case AnimationActivationMode.SET_TRIGGER:
                        animator?.SetTrigger(paramName);
                        break;
                }
            }
        }
    }
}

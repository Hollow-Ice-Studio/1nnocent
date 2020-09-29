using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace onennocent
{
    [RequireComponent(typeof(AnimatorController))]
    public class Character : MonoBehaviour
    {
        #region Properties
        Animator CharacterAnimator;
        #region Serializable Fields
        #endregion
        #endregion

        #region MonoBehaviour
        void Start()
        {
            Build();
        }
        #endregion

        #region CustomMethods
        void Build()
        {
            CharacterAnimator = GetComponent<Animator>();
        }
        #endregion
        
    }
}


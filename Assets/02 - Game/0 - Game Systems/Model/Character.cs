using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace innocent
{
    [RequireComponent(typeof(AnimatorController))]
    public class Character : MonoBehaviour
    {
        #region Properties
        Animator _characterAnimator;
        public Animator CharacterAnimator { get => _characterAnimator;}
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
            _characterAnimator = GetComponent<Animator>();
        }
        #endregion
        
    }
}


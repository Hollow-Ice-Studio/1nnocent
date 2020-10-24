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
        public Transform TargetRotationTransform;
        public float LifeValue;
        public Animator CharacterAnimator { get => _characterAnimator;}
        #endregion

        #region MonoBehaviour
        void Start() => CacheReferences();
        #endregion

        #region Custom Methods
        void CacheReferences() => _characterAnimator = GetComponent<Animator>();
        #endregion
        
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        #region Properties
        string targetRotationName = "TargetRotation";
        Animator _characterAnimator;
        public Transform TargetRotationTransform;
        public float LifeValue = 2;
        public Animator CharacterAnimator { get => _characterAnimator;}
        #endregion

        #region MonoBehaviour
        void Reset() => SearchDependentGameObjects();
        void Start() => CacheReferences();
        #endregion

        #region Custom Methods
        void SearchDependentGameObjects() =>
            TargetRotationTransform = GameObject.Find(targetRotationName)?.transform;
        void CacheReferences() => _characterAnimator = GetComponent<Animator>();
        #endregion
        
    }
}


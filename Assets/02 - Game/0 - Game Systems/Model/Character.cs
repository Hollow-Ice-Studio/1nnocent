using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace panorama
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
    public class Character : MonoBehaviour
    {
        #region Properties
        Rigidbody2D _rb2d;
        public Rigidbody2D Rb2d { get { return _rb2d; } }
        public Animator characterAnimator;
        #endregion

        #region Serializable Fields
        //TODO: Pensar em como gerenciar multicontroller
        //[SerializeField]
        //AnimatorController[] animatorControllers;
        #endregion

        #region MonoBehaviour
        void Awake()
        {
            characterAnimator = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
        }
        #endregion

        #region CustomMethods
        public void FlipSpriteDirection(bool isFlipped)
        {
            GetComponent<SpriteRenderer>().flipX = isFlipped;
        }
        #endregion
        
    }
}


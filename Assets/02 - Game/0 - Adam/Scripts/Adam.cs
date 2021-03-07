using UnityEngine;

namespace innocent
{
    //Script Responsável pela manutenção de Atributos do personagem Adam
    [RequireComponent(typeof(Animator))]
    public class Adam : MonoBehaviour
    {
        #region Properties
        public float LifeValue = 2;
        public Animator _characterAnimator;
        public Animator CharacterAnimator { get => _characterAnimator; }
        public string targetRotationName = "TargetRotation";
        public Transform TargetRotationTransform;
        public float
            speed = 1,
            runningSpeed = 4,
            jumpHeight = 1;
        public bool IsGrounded;
        public Vector3 velocity;
        public float beamdistance;
        public Rigidbody rig;
        public Animator animator;
        [HideInInspector]
        public float
            initialSpeed = 1,
            initialJumpHeight = 1;
        #endregion

        #region MonoBehaviour
        void Reset() => SearchDependentGameObjects();
        void Start() => CacheReferences();
        #endregion

        protected void CacheReferences()
        {
            _characterAnimator = GetComponent<Animator>();
            rig = GetComponent<Rigidbody>();
            beamdistance = transform.localScale.y + .2f;
            animator = GetComponent<Animator>();
            this.transform.rotation = Quaternion.identity;
            initialSpeed = speed;
            initialJumpHeight = jumpHeight;
        }

        #region Custom Methods
        void SearchDependentGameObjects()
        {
            TargetRotationTransform = GameObject.Find(targetRotationName)?.transform;
        }
        #endregion

    }
}


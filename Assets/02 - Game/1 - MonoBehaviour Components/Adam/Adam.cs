using UnityEngine;

namespace innocent
{
    

    //Classe base de todos os personagens
    public abstract class Character : MonoBehaviour
    {
        public float LifeValue = 2;
        public Animator _characterAnimator;
        public Animator CharacterAnimator { get => _characterAnimator; }

        protected void CacheReferences() => _characterAnimator = GetComponent<Animator>();
    }

    //Script Responsável pela manutenção de Atributos do personagem Adam
    [RequireComponent(typeof(Animator))]
    public class Adam : Character
    {
        #region Properties
        string targetRotationName = "TargetRotation";
        public Transform TargetRotationTransform;
        #endregion

        #region MonoBehaviour
        void Reset() => SearchDependentGameObjects();
        void Start() => base.CacheReferences();
        #endregion

        #region Custom Methods
        void SearchDependentGameObjects()
        {
            TargetRotationTransform = GameObject.Find(targetRotationName)?.transform;
            CacheReferences();
        }
        #endregion

    }
}


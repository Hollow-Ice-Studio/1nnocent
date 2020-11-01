using innocent;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public partial class CharacterAnimationSystem : GameSystem
    {
        #region Properties
        string NotificationName = Notification.ANIMATION_PLAY;
        public Animator animator;
        #endregion

        #region MonoBehaviour Event Functions
        void Reset() => CacheReferences();
        void Start() => CacheReferences();
        void OnEnable()  => this.AddObserver(PlayAnimationOnNotification, NotificationName);
        void OnDisable() => this.RemoveObserver(PlayAnimationOnNotification, NotificationName);
        void OnDestroy() => this.RemoveObserver(PlayAnimationOnNotification, NotificationName);
        #endregion

        #region Notification Handler
        void PlayAnimationOnNotification(object sender, object args) => animator.Play(args as string);
        #endregion
       
        #region Start
        void CacheReferences()
        {
            animator = animator != null ? animator : (FindObjectOfType<Character>()?.GetComponent<Animator>());
        }
        #endregion

    }
}


using innocent;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public partial class CharacterAnimationSystem : GameSystem
    {
        private string NotificationName = Notification.ANIMATION_PLAY;

        #region MonoBehaviour
        void Start() => CacheReferences();

        void OnEnable() => this.AddObserver(PlayAnimationOnNotification, NotificationName);

        void OnDisable() => this.RemoveObserver(PlayAnimationOnNotification, NotificationName);

        void OnCollisionEnter(Collision collision) => doSomethingOnCollision(collision);
        #endregion

        #region IGameSystem
        public override void LogicRoutine() => AdamSpecificAnimationsActivation();
        #endregion
        
        #region Notification Handler
        void PlayAnimationOnNotification(object sender, object args) => animator.Play(args as string);
        #endregion

    }
}


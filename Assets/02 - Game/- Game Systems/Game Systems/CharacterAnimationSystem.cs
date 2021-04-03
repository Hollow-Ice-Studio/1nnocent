using UnityEngine;
using TheLiquidFire.Notifications;

namespace innocent
{
    public class CharacterAnimationSystem : GameSystem
    {
        CharacterAnimationSystem() => NotificationName = Notification.ANIMATION_PLAY;

        public Animator animator;
        
        protected override void NotificationHandler(object sender, object args) 
            => animator.Play(args as string);

        protected override void CacheReferences() 
            => animator = animator != null ? animator : (FindObjectOfType<Adam>()?.GetComponent<Animator>());

    }
}


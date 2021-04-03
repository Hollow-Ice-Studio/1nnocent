using UnityEngine;
using TheLiquidFire.Notifications;
using UnityEngine.Playables;

namespace innocent
{
    public class CutSceneSystem : GameSystem
    {
        CutSceneSystem() => NotificationName = Notification.CUTSCENE_PLAY;

        public PlayableDirector director;

        protected override void NotificationHandler(object sender, object args)
            => PlayCutScene(args);

        protected override void CacheReferences() 
            => director = director != null ? director : GetComponent<PlayableDirector>();

        private void PlayCutScene(object args)
        {
            PlayableAsset playable = args as PlayableAsset;
            if(playable)
                director.Play(playable);
            else
                this.PostNotification(Notification.HUD_WRITE, "Não foi possível rodar uma cutscene");
        }
    }
}


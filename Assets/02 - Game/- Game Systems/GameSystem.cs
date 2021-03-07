using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    //ᚨᛒᚲᛞᛖᚠᚷᚺᛁᛃᚲᛚᛗᚾᛟᛈᚲᚱᛊᛏᚢᚢᚹXᛁᛉ×ᚦ×ᛜ
    //abkdefghijklmnopkrstuuwXiz'þ'ŋ
    //https://valhyr.com/pages/rune-translator

    public interface IGameSystem
    {
        void CacheReferences();
        void AddObservers();
        void RemoveObservers();
    }

    public abstract class GameSystem : MonoBehaviour
    {
        protected string NotificationName;
        #region MonoBehaviour Event Functions
        void Reset() => CacheReferences();
        void Start() => CacheReferences();
        void OnEnable()  => AddObserver();
        void OnDisable() => RemoveObserver();
        void OnDestroy() => RemoveObserver();
        #endregion

        protected virtual void CacheReferences() { }
        protected virtual void NotificationHandler(object sender, object args) {}

        void AddObserver()
        => this.AddObserver(NotificationHandler, NotificationName);
        
        void RemoveObserver()
        => this.RemoveObserver(NotificationHandler, NotificationName);
        

    }
}


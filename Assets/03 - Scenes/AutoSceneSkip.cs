using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace innocent
{
    public class AutoSceneSkip : MonoBehaviour
    {
        
        [SerializeField]
        string sceneName;

        float timeToSkipInSeconds;

        void Start() =>
            timeToSkipInSeconds = GetComponent<AudioSource>().clip.length;
        
        void Update()
        {
            if (Time.time > timeToSkipInSeconds)
                SceneManager.LoadScene(sceneName);
        }
    }
}
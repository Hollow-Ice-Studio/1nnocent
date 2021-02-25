using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace innocent
{
    public class AutoSceneSkip : MonoBehaviour
    {
        
        [SerializeField]
        string SceneName;
        float TimeToSkipInSeconds;

        void Start() =>
            TimeToSkipInSeconds = GetComponent<AudioSource>().clip.length;
        
        void Update()
        {
            if (Time.time > TimeToSkipInSeconds)
                SceneManager.LoadScene(SceneName);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace innocent
{
    public class AutoSceneSkip : MonoBehaviour
    {
        
        [SerializeField]
        string SceneName;
        float TimeToSkipInSeconds;

        void Start()
        {
            var audioSource = GetComponent<AudioSource>();
            if(audioSource)
                TimeToSkipInSeconds = audioSource.clip.length;
            else
                TimeToSkipInSeconds = (float) GetComponent<VideoPlayer>().length;
        }
            
        
        void Update()
        {
            if (Time.time > TimeToSkipInSeconds)
                SceneManager.LoadScene(SceneName);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public class AudioManagerPlayer : MonoBehaviour
    {
        public void SelectAndPlaySound(string name)
            => FindObjectOfType<AudioManager>().Play(name);//"MovingDoors"
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void SelectAndPlaySound(string name)
    {
        FindObjectOfType<AudioManager>().Play("MovingDoors");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Onennocent/Gun", order = 1)]
    public class GunScriptableObject : ScriptableObject
    {
        public string
            description;
        public float
            impulse = 50,
            distance = 1000,
            totalAmmo = 16,
            currentAmmo = 0;
        public AudioClip
            shootingSound,
            reloadingSound;
    }
}

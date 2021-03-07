using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public class AdamJumpController : MonoBehaviour
    {
        Adam adam;
        private void Start() => adam = GetComponent<Adam>();
        void Update() => AppointGrounded();
        private void AppointGrounded()
        {
            var origin = transform.position + (transform.up * adam.beamdistance);
            if (Physics.Raycast(
                    origin, -transform.up, adam.beamdistance * 2))
                adam.IsGrounded = true;
            else
                adam.IsGrounded = false;
            Debug.DrawRay(transform.position + (transform.up * adam.beamdistance), -transform.up * adam.beamdistance * 2, Color.red);
        }
    }
}

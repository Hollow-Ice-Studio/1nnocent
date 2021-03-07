using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public class BehavioursTriggeredByAnimation : MonoBehaviour
    {
        Adam adam;
        void Start() => adam = GetComponent<Adam>();
        //Esse método é ativado a partir da animação de pulo
        private void PlayerJumpTriggeredByAnimation()
        {
            //nao necessita de getKey no método de pulo se estiver ativando via animação
            if (adam.IsGrounded)
            {
                var forceDirection = Vector3.up * Mathf.Sqrt(adam.jumpHeight * -2f * Physics.gravity.y);
                Debug.Log(forceDirection);
                adam.rig.AddForce(forceDirection, ForceMode.VelocityChange);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField]
    KeyCode activationButton;
    [SerializeField]
    bool isActivated;
    [SerializeField]
    Transform elevatorTransform;
    [SerializeField]
    float height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter()
    {
        if (isActivated)
        {
            elevatorTransform.Translate(elevatorTransform.up * height);
            isActivated = false;
        }
        else
        {
            elevatorTransform.Translate(elevatorTransform.up * height * -1);
            isActivated = true;
        }
    }
}

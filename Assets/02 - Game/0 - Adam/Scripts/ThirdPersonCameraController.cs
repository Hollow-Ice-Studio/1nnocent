using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform player, target;
    public float rotationSpeed;
    public KeyCode frontCameraKey;
    float mouseX=100, mouseY;//São essas variaveis que modifica o estado inicial de rotação
    public float defaultFieldOfView = 50, zoomingFieldOfView = 45, runningFieldOfView = 70;
    public float cameraDistance, cameraAdjustmentSpeed;
    float InitialCameraDistance;
    private Camera cameraComponent;
    Animator animator;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        InitialCameraDistance = transform.position.z;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        cameraComponent.fieldOfView = 
            (Input.GetMouseButton(1)) ? zoomingFieldOfView : 
            (animator.GetBool("isRunning")) ? runningFieldOfView : defaultFieldOfView;
       
        Debug.DrawRay(target.position, -target.forward * cameraDistance, Color.red);
        RaycastHit objectDetetected;
        
        Physics.Raycast(target.position, -target.forward, out objectDetetected, cameraDistance, LayerMask.NameToLayer("Trigger"));
        if (objectDetetected.distance > 0.5)
        {
            transform.position = objectDetetected.point;
        }
        else if (objectDetetected.distance == 0 && cameraDistance > Vector3.Distance(transform.position,target.position))
        {
            transform.Translate(Vector3.back * cameraAdjustmentSpeed, Space.Self);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }
    
    void CamControl()
    {
        //mouseY -= Input.GetAxis("VerticalJoyR") * rotationSpeed;
        //mouseX += Input.GetAxis("HorizontalJoyR") * rotationSpeed;
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);
        transform.LookAt(target);

        if (!Input.GetKey(frontCameraKey)){
            player.rotation = Quaternion.Euler(0, mouseX, 0);
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            player.rotation = Quaternion.Euler(0, mouseX, 0);
            target.rotation = Quaternion.Euler(mouseY, mouseX + 180, 0);
        }
        
    }
}

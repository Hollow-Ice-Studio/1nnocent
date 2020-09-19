using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableObjectController : MonoBehaviour
{
    [SerializeField]
    GameObject pickablePrefabVersion;
    [SerializeField]
    GameObject equipablePrefabVersion;
    [SerializeField]
    Text uiTextElement;
    [SerializeField]
    KeyCode buttonToPick;
    public string showText;

    private bool isInside = false;
    // Start is called before the first frame update
    void Awake()
    {
        uiTextElement.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = true;
            uiTextElement.text = $"{showText}\n [{buttonToPick.ToString()}]";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
            uiTextElement.text = "";
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(isInside && Input.GetKeyDown(buttonToPick))
        {
            uiTextElement.text = "";
            var weaponSlot = other.GetComponent<ThirdPersonWeaponSlotsController>();
            weaponSlot.ChangeWeapon(equipablePrefabVersion, pickablePrefabVersion);
            GameObject.Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}


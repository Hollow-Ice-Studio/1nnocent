using UnityEngine;

public class DesceElevadorActivator : MonoBehaviour
{

    public GameObject ElevadorLabirinto;
    public GameObject Portinha1;

    Animator elevadorLabAnim;
    Animator portinha1;

    void Start()
    {
        elevadorLabAnim = ElevadorLabirinto.GetComponent<Animator>();
        portinha1 = Portinha1.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entrou");
        if (collider.gameObject.tag == "Player")
        {
            CanGoDown(true);
        }
    }


    void CanGoDown(bool state)
    {
        elevadorLabAnim.SetBool("goDown", state);
        portinha1.SetBool("goDown", state);
    }
}

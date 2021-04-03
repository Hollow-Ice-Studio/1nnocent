using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PedrasCaemActivator : MonoBehaviour
{
    public GameObject trigger;
    public GameObject suporte;

    Animator suporteAnim;

    [SerializeField]
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        suporteAnim = suporte.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Entrou");

        if (coll.gameObject.tag == "Player")
        {
            Fallrocks(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
       //     SceneManager.LoadScene(sceneName);
        }
        
    }

    void Fallrocks(bool state)
    {
        suporteAnim.SetBool("fall", state);
        
    }

}

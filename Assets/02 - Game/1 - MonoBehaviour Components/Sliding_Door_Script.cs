using UnityEngine;

public class Sliding_Door_Script : MonoBehaviour
{

    public GameObject Detector;
    public GameObject Porta_esquerda;
    public GameObject Porta_direita;
    public GameObject Labirinto;
    public GameObject ElevadorLabirinto;
    public GameObject Portinha1;
    
    Animator esquedaAnim;
    Animator diretaAnim;
    Animator labirintoAnim;
    Animator elevadorLabAnim;
    Animator portinha1;

    // Start is called before the first frame update
    void Start()
    {
        esquedaAnim = Porta_esquerda.GetComponent<Animator>();
        diretaAnim = Porta_direita.GetComponent<Animator>();
        labirintoAnim = Labirinto.GetComponent<Animator>();
        elevadorLabAnim = ElevadorLabirinto.GetComponent<Animator>();
        portinha1 = Portinha1.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entrou");
        if (collider.gameObject.tag == "Player")
        {
            SlideDoors(true);
        }
    }

    /*private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SlideDoors(false);
        }
    }*/

    void SlideDoors (bool state)
    {
        esquedaAnim.SetBool("slide", state);
        diretaAnim.SetBool("slide", state);
        labirintoAnim.SetBool("slide", state);
        elevadorLabAnim.SetBool("slide", state);
        portinha1.SetBool("slide", state);
    }
}

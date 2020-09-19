using UnityEngine;

public class Labirinto_MaxH : MonoBehaviour
{
    public GameObject Detector;
    public GameObject Labirinto;

    Animator labirintoAnim;

    // Start is called before the first frame update
    void Start()
    {
        labirintoAnim = Labirinto.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entrou");
        if (collider.gameObject.tag == "Player")
        {
            LabirintoUp(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LabirintoUp(bool state)
    {
        labirintoAnim.SetBool("subir", state);
    }
}

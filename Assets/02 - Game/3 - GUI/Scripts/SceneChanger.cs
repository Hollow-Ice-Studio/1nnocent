using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneChanger : MonoBehaviour
{
    [Range(0.5f,3f),SerializeField] float quantidadeDeSegundosParaEsperarAntesDeMudarDeCena;
    [SerializeField] AudioSource AudioSourceComEfeitoSonoro;
    
    public void ExitGame()
        => Application.Quit();
    

    public void ChangeScene(string sceneName)
        => StartCoroutine(WaitAndChangeScene(quantidadeDeSegundosParaEsperarAntesDeMudarDeCena, sceneName));
    

    private IEnumerator WaitAndChangeScene(float waitTime,string sceneName)
    {
        AudioSourceComEfeitoSonoro.Play();
        yield return new WaitForSeconds(waitTime);
        Debug.Log($"Scene changed to: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField]
    GameObject victoriousPlayer;
    [SerializeField]
    Text targetCounterUITextElement;
    public int currentTargets=0, totalTargets=3;

    public void IncreaseTarget()
    {
        currentTargets++;
        targetCounterUITextElement.text = $"{currentTargets}/{totalTargets}";
        if (currentTargets == totalTargets)
        {
            targetCounterUITextElement.text = "SUCESSO";
            Instantiate(victoriousPlayer,Vector3.zero,Quaternion.identity,null);
        }
    }
}

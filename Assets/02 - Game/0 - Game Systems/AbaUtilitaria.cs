using UnityEngine;
using UnityEditor;

public class AbaUtilitaria : ScriptableObject
{
    [MenuItem("Innocent/Olha só uma aba utilitária")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("Titulo", "Não implementado ainda", "Okay", "Cancele");
    }
}
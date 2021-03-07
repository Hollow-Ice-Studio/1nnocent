using UnityEngine;
using UnityEditor;

namespace innocent {
    public class AbaUtilitaria : ScriptableObject
    {
        [MenuItem("Innocent/Instânciar GameController")]
        static void instatiateGameController()
        {
            if (EditorUtility.DisplayDialog("Instânciar GameController", "Deseja instanciar uma gameController na cena?", "Sim", "Cancele"))
            {
                DynamicAssets.Instantiate("GameSystems/GameController");
            }
        }
    }
}
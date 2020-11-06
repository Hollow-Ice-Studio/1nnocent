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
                var existsInScene = FindObjectOfType<GameController>() != null;
                if (existsInScene)
                {
                    EditorUtility.DisplayDialog("Aviso", "Ja Existe um gameController na cena", "Entendido");
                }
                else
                {
                    DynamicAssets.Instantiate("GameSystems/GameController");
                }
                
            }
        }
    }
}
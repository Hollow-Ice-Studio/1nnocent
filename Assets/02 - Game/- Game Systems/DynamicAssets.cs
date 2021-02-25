using UnityEngine;

namespace innocent {
    public static class DynamicAssets
    {
        public static GameObject Instantiate(string dynamicAssetResourceRelativePath)
        {
            GameObject loadedAsset = Resources.Load<GameObject>(dynamicAssetResourceRelativePath);
            if (loadedAsset == null)
                throw new System.Exception($"GameObject não encontrado em: 'Dynamic Assets/Resource/{dynamicAssetResourceRelativePath}'");
            var instatiatedGameObject = Object.Instantiate(loadedAsset);
            instatiatedGameObject.name = instatiatedGameObject.name.Replace("(Clone)", " (Instânciada Dinâmicamente)").Trim();
            return instatiatedGameObject;
        }

        public static GameObject Instantiate(GameObject original,Transform parent)
        {
            var instatiatedGameObject = Object.Instantiate(original, parent);
            instatiatedGameObject.name = instatiatedGameObject.name.Replace("(Clone)", "").Trim();
            return instatiatedGameObject;
        }
    }
}
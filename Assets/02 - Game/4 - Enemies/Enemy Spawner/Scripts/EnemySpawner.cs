using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public class EnemySpawner : MonoBehaviour
    {
        const string PREFAB_PATH = "Prefabs/Enemy Stalker/Enemy Stalker Prefab";
        GameObject enemyPrefab;

        private void Awake()
        {
            enemyPrefab = Resources.Load<GameObject>(PREFAB_PATH);
            if (enemyPrefab == null)
                throw new MissingReferenceException("Verifique se há um prefab valido no caminho fornecido");
            Spawn();
        }

        void Spawn()
        {
            GameObject enemyObj = Instantiate(enemyPrefab, transform.localPosition, transform.rotation);
            enemyObj.name = $"[Enemy] {name}";
            enemyObj.layer = LayerMask.NameToLayer(ConfiguredLayers.ENEMY);
        }
    }
}
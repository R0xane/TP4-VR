using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Assurez-vous de lier votre prefab de cible
    public float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            float x = Random.Range(-2f, 2f);
            float y = 1f; // hauteur de spawn
            float z = Random.Range(-2f, 2f);
            Vector3 spawnPosition = new Vector3(x, y, z);
            Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

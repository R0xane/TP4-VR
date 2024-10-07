using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
   public float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Démarre la coroutine pour détruire le GameObject après un certain temps
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    // Coroutine pour détruire l'objet après le délai spécifié
    private IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // Détruire le GameObject
    }

    public void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject); // Détruire la cible
    }
}

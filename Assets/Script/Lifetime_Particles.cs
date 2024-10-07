using System.Collections;
using UnityEngine;

public class Lifetime_Particles : MonoBehaviour
{
    // Durée de vie des particules en secondes
    public float lifetime = 2f;

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
}

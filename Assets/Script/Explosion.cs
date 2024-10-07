using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public GameObject explosionEffect; // Préfabriqué de l'effet de particule

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Détruire la cible
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }

}

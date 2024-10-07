using UnityEngine;
using UnityEngine.InputSystem; // Assurez-vous d'importer le namespace InputSystem

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Référence au prefab de la sphère
    public Transform spawnPoint; // Position de spawn de la sphère
    public bool isGrab = false; // Vérifie si l'arme est saisie

    public GameObject hand_right; // Référence à la main
    public GameObject hand_left; // Référence à la main

    void Start()
    {


    }

    void Update()
    {
        // Vous pouvez gérer d'autres logiques ici si nécessaire
    }

    // Cette méthode sera appelée lorsque la gâchette est pressée
    void FireBullet()
    {
        // Vérifier si isGrab est true avant de tirer
        if (isGrab)
        {
            // Créer une sphère à la position de spawn
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Bullet fired!");
        }
    }

    // Détection de la collision pour savoir si une main touche le pistolet
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Hand"))
        {
            isGrab = true;  // L'arme est saisie
            Debug.Log("Gun grabbed!");
        }
    }

    // Détection du relâchement de l'arme
    private void OnTrigerExit(Collider collision)
    {
        if (collision.CompareTag("Hand"))
        {
            isGrab = false;  // L'arme est relâchée
            Debug.Log("Gun released!");
        }
    }
}

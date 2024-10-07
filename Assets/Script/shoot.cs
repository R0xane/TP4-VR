using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public InputActionProperty triggerAction; // Input Action pour la gâchette
    public GameObject bulletPrefab; // Prefab de la balle
    public Transform barrelEnd; // Position de départ de la balle
    public float bulletForce = 500f; // Force du tir

    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Créer la balle à l'emplacement du canon
        GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(barrelEnd.forward * bulletForce, ForceMode.Impulse); // Appliquer la force à la balle
    }
}

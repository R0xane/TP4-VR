using UnityEngine;
using UnityEngine.InputSystem; // Import the InputSystem namespace
using UnityEngine.XR.Interaction.Toolkit; // Import the XR.Interaction.Toolkit namespace

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform spawnPoint; // Reference to the spawn point (must be a Transform)
    public GameObject gun; // Reference to the gun object
    public float bulletSpeed = 10f; // Speed of the bullet, editable in the editor
    public float detachDistance = 1f; // Distance at which the bullet detaches from the spawn point

    public void SpawnBullet()
    {
        // Instantiate the bullet prefab at the spawn point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Set the parent of the bullet to the spawn point
        bullet.transform.SetParent(spawnPoint);
        
        // Get the Rigidbody component from the bullet prefab
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Set the bullet's velocity based on the forward direction of the spawn point
            rb.velocity = spawnPoint.forward * bulletSpeed; // Uses the user-defined speed
        }

        // Start a coroutine to detach the bullet after it moves a certain distance
        StartCoroutine(DetachBullet(bullet));
    }

    private System.Collections.IEnumerator DetachBullet(GameObject bullet)
    {
        // Wait until the bullet has moved beyond the detach distance
        while (Vector3.Distance(bullet.transform.position, spawnPoint.position) < detachDistance)
        {
            yield return null; // Wait for the next frame
        }

        // Detach the bullet from the spawn point
        bullet.transform.SetParent(null);
    }
}

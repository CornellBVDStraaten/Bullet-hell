using Projectiles;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float degreesPerSec = 360f;
    public Transform LaunchOffset;
    public float projectileSpeed = 10f;
    
    public Basic BasicProjectilePrefab;    // Basic projectile prefab
    public Enhanced EnhancedProjectilePrefab;  // Enhanced projectile prefab

    private BaseProjectile currentProjectile;  // Reference to current projectile type
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentProjectile = BasicProjectilePrefab;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = degreesPerSec * Time.deltaTime;
        float currentRotation = transform.localRotation.eulerAngles.z;
        
        // Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation - rotationAmount));
        }
        
        // Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation + rotationAmount));
        }
        
        // Switch projectile type
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentProjectile = BasicProjectilePrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 0.75f;
            currentProjectile = EnhancedProjectilePrefab;
        }

        
        // Fire projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BaseProjectile projectile = Instantiate(currentProjectile, LaunchOffset.position, transform.rotation);
            // Calculate direction based on the object's rotation
            float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
        }
    }
}
using Enemies;
using UnityEngine;

namespace Projectiles
{
    public class BaseProjectile : MonoBehaviour
    {
        [SerializeField] public float speed = 10f;
        [SerializeField] protected float lifetime = 3f; // Projectile will be destroyed after this many seconds
        private float direction = 1f; // 1 for right, -1 for left
        [SerializeField] protected float damage = 10f;  // Base damage value

        void Start()
        {
            // Get the direction from the player's scale
            // Assuming the projectile is instantiated by the player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // If player is facing left (scale.x is negative), direction will be -1
                direction = Mathf.Sign(player.transform.localScale.x);
            }
        
            // Destroy the projectile after lifetime seconds
            Destroy(gameObject, lifetime);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            UpdateMovement();
        }
    
        protected virtual void UpdateMovement()
        {
            transform.position += new Vector3() * (direction * speed * Time.deltaTime);
        }
    
        protected virtual void OnHit(Collision2D collision)
        {
            var shootable = collision.gameObject.GetComponent<IShootable>();
            if (shootable != null)
            {
                shootable.Damage(damage);
            }
            
            Destroy(gameObject);
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnHit(collision);
        }
    }
}

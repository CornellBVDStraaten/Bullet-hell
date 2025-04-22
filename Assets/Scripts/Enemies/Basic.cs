using UnityEngine;

namespace Enemies
{
    public class Basic : MonoBehaviour, IShootable
    {
        [SerializeField] private int health = 100;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"Collision detected with {collision.gameObject.name}");
        }
        
        public void Damage(float damageTaken)
        {
            health -= (int)damageTaken;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

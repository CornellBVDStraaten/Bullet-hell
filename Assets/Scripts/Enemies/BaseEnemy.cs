using System;
using UnityEngine;

namespace Enemies
{
    public class BaseEnemy : MonoBehaviour, IShootable
    {
        [SerializeField] private int health = 100;
        [SerializeField] private float speed = 5f;      // Movement speed
        [SerializeField] private float rotateSpeed = 20f; // Optional: rotation speed

        public string playerTag = "Player"; // Make sure the player has this tag
        private Transform player;
        
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

        void Start()
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
        
        private void Update()
        {
            if (player == null) return;

            // Move towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * (speed * Time.deltaTime);
            
            float currentRotation = transform.localRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation - rotateSpeed));

        }
    }
}

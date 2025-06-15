/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: LAVA AND DEAL DAMAGE
*/
using UnityEngine;

public class Lava : MonoBehaviour
{
    int damage = 50; // Amount of damage dealt per second

    public void TakeDamage(PlayerBehaviour player)
    {
        player.ModifyHealth(-damage); // Instantly reduce player's health
        // Optionally, add sound or animation here
    }

    void OnCollisionStay(Collision other)
    {
        // Called every frame while another collider stays in contact
        if (other.gameObject.CompareTag("Player")) // Check if the collider is the player
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>(); // Get the PlayerBehaviour script
            if (player == null)
            {
                // Try to get from parent if not found on this object
                player = other.gameObject.GetComponentInParent<PlayerBehaviour>();
            }
            if (player != null)
            {
                player.ModifyHealth(-damage * Time.deltaTime); // Apply damage over time to the player
            }
            else
            {
                Debug.LogWarning("PlayerBehaviour not found on collided object!");
            }
        }
    }
}
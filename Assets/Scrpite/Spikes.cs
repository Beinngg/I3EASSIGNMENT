/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: DEAL DAMAGE WHEN INTERACTING WITH SPIKES
*/
using UnityEngine;

public class Spikes : MonoBehaviour
{
    int damage = 40; // Amount of damage dealt per second

    public void TakeDamage(PlayerBehaviour player)
    {
        player.ModifyHealth(-damage * Time.deltaTime); // Reduce player's health over time
        // Optionally, add sound or animation here
    }

    public void OnCollisionStay(Collision other)
    {
        // Called every frame while another collider stays in contact
        if (other.gameObject.CompareTag("Player")) // Check if the collider is the player
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>(); // Get the PlayerBehaviour script
            if (player != null)
            {
                TakeDamage(player); // Apply damage to the player
            }
        }
    }
}
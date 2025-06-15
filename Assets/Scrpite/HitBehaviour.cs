/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: HIT AND DEAL DAMAGE PER SECOND
*/
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    [SerializeField] int damage = 2; // Amount of damage dealt per second

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
            if (player != null) // Check if PlayerBehaviour is found on the collided object
            {
                player.ModifyHealth(-damage * Time.deltaTime); // Apply damage over time to the player
                Debug.Log("Player is taking damage: " + damage * Time.deltaTime);
            }
            else
            {
                Debug.LogWarning("PlayerBehaviour not found on collided object!");
            }
        }
    }
}
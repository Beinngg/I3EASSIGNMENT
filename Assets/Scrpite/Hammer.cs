/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: ROTATE AND DEAL DAMAGE 
*/
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2f; // Speed of rotation in degrees per second
    [SerializeField] int damage = 30; // Amount of damage dealt per hit

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // Rotate the hammer around the Z-axis
    }

    void OnCollisionEnter(Collision other)
    {
        // Called when the hammer first hits another collider
        if (other.gameObject.CompareTag("Player")) // Check if the collider is the player
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>(); // Get the PlayerBehaviour script
            if (player != null)
            {
                player.ModifyHealth(-damage); // Apply instant damage
            }
        }
    }
}
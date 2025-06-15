/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: ROTATE AND DEAL DAMAGE
*/
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2f; // Speed of rotation in degrees per second
    [SerializeField] int damage = 5; // Amount of damage dealt per second

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // Rotate the object around the Y-axis
    }

    void OnCollisionStay(Collision other)
    {
        // Called every frame while another collider stays in contact
        if (other.gameObject.CompareTag("Player")) // Check if the collider is the player
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>(); // Get the PlayerBehaviour script
            if (player != null)
            {
                player.ModifyHealth(-damage * Time.deltaTime); // Apply damage over time to the player
            }
        }
    }
}
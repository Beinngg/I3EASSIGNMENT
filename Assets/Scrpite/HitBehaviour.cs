using UnityEngine;

using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    float damage = 5f;
    public void TakeDamage(PlayerBehaviour player)
    {
        // Log the damage taken
        player.ModifyHealth(-damage);

        // Optionally, you can add additional logic here, such as playing a sound or animation
    }
    void OnCollisionEnter(Collision other)
    {
        // Check if the collided object has the tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Log the hit
            Debug.Log("Hit by player");

            // Call the TakeDamage method on the player object
            other.gameObject.GetComponent<PlayerBehaviour>().ModifyHealth(-damage);
        }
    }
}
using UnityEngine;

public class Spikes : MonoBehaviour
{
    int damage = 40;

    public void TakeDamage(PlayerBehaviour player)
    {
        player.ModifyHealth(-damage * Time.deltaTime); // Damage over time
        // Optionally, add sound or animation here
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (player != null)
            {
                TakeDamage(player);
            }
        }
    }
}
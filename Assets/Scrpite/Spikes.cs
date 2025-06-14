using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float damage = 40f;
    public void TakeDamage(PlayerBehaviour player)
    {
        player.ModifyHealth(-damage);
        // Optionally, add sound or animation here
    }
    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();

        }
    }

}
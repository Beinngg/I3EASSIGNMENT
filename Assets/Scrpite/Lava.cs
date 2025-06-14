using UnityEngine;

public class Lava : MonoBehaviour
{
    float damage = 50f;

    public void TakeDamage(PlayerBehaviour player)
    {
        player.ModifyHealth(-damage);
        // Optionally, add sound or animation here
    }



    void OnCollisionStay(Collision other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
        if (player == null)
        {
            // Try to get from parent if not found on this object
            player = other.gameObject.GetComponentInParent<PlayerBehaviour>();
        }
        if (player != null)
        {
            player.ModifyHealth(-damage * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("PlayerBehaviour not found on collided object!");
        }
    }
}
}

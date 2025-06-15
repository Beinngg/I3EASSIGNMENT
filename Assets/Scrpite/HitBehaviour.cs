using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    [SerializeField]int damage = 2;

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
            if (player != null)// Check if PlayerBehaviour is found on the collided object
            {
                player.ModifyHealth(-damage * Time.deltaTime);
                Debug.Log("Player is taking damage: " + damage * Time.deltaTime);
        }

            else
            {
                Debug.LogWarning("PlayerBehaviour not found on collided object!");
            }
    }
}
}
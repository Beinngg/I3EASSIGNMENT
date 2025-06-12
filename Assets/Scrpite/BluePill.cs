using UnityEngine;

public class BluePill : MonoBehaviour
{
    [SerializeField] float damage = 1000f;
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the blue pill
        Debug.Log("Blue pill collected!");

        // Apply damage to the player
        player.ModifyHealth(-damage);

        Destroy(gameObject&&gameObject.tag=="RedPill"); // Destroy the blue pill object
// Destroy the blue pill object
    }
}

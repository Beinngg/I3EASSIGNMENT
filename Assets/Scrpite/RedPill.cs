using UnityEngine;

public class RedPill : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the red pill
        Debug.Log("Red pill collected!");

        // Apply a specific effect to the player, e.g., increase health
        player.transform .position= new Vector3(0,0,0); 

        Destroy(gameObject); // Destroy the red pill object
    }
}

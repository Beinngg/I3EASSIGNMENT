using UnityEngine;

public class RedPill : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Renderer rend;
    private Color originalColor;
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the red pill
        Debug.Log("RED pill collected!");

        // Apply a specific effect to the player, e.g., increase health
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        player.transform.position = new Vector3(2f, 0f, 6f);
        if (cc != null) cc.enabled = true; // Example: increase health by 50

        Destroy(gameObject); // Destroy the red pill object
    }
    public void Highlight()
    {
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        }
    }



    public void Unhighlight()
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}

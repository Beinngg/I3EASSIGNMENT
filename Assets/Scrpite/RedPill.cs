/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: TELEPORT AFTER COLLECT 
*/
using UnityEngine;

public class RedPill : MonoBehaviour
{
    private Renderer rend; // Stores the Renderer component for color changes
    private Color originalColor; // Stores the original color for restoring

    public void Collect(PlayerBehaviour player)
    {
        // Called when the player collects the red pill
        Debug.Log("RED pill collected!");

        // Temporarily disable CharacterController to teleport the player
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        player.transform.position = new Vector3(2f, 0f, 6f); // Teleport player
        if (cc != null) cc.enabled = true;

        Destroy(gameObject); // Destroy the red pill object after collection
    }

    public void Highlight()
    {
        // Change color to yellow for highlighting
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        }
    }

    public void Unhighlight()
    {
        // Restore the original color when not highlighted
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}
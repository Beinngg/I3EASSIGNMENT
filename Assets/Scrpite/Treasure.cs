/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: END GOAL TO COLLECT THIS AND WIN GAME
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Treasure : MonoBehaviour
{
    [SerializeField] GameObject win; // Reference to the win screen or object

    private Renderer rend; // Stores the Renderer component for color changes
    private Color originalColor; // Stores the original color for restoring

    public void Collect(PlayerBehaviour player)
    {
        // Called when the player collects the treasure; destroys the treasure object
        Destroy(gameObject);
    }

    public void Highlight()
    {
        // Changes the treasure's color to yellow for highlighting
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        }
    }

    public void Unhighlight()
    {
        // Restores the treasure's original color when not highlighted
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}
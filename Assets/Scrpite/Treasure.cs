using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class Treasure : MonoBehaviour
{
    [SerializeField] GameObject win;
    
    private Renderer rend;
    private Color originalColor;

    public void Collect(PlayerBehaviour player)
    {
        // Initialize the treasure
        Destroy(gameObject);
    }
    public void Highlight()
    {
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        } }



    public void Unhighlight()
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}



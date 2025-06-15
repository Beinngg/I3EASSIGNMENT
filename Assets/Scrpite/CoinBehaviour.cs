/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: PICK POINTS AND ADD SCORE TO PLAYER
*/
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    int coinValue = 1;
    private Renderer rend;
    private Color originalColor;
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the coin
        Debug.Log("Coin collected!");

        // Add the coin value to the player's score
        player.ModifyScore(coinValue);

        Destroy(gameObject); // Destroy the coin object
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

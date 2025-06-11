using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    int coinValue = 1;
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the coin
        Debug.Log("Coin collected!");

        // Add the coin value to the player's score
        player.ModifyScore(coinValue);

        Destroy(gameObject); // Destroy the coin object
    }
}

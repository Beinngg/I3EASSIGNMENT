using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float CurrentHealth = 100f;
    int CurrentScore = 0;
    bool CanInteract = false;
    CoinBehaviour CurrentCoin = null;

    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
        else
        {
            Debug.Log("Player is alive " + CurrentHealth);
        }
    }

    void OnInteract()
    {
        if (CanInteract && CurrentCoin != null)
        {
            Debug.Log("Interacting with coin");
            CurrentCoin.Collect(this);
        }
    }

    public void ModifyScore(int amount)
    {
        CurrentScore += amount;
        Debug.Log("Current Score: " + CurrentScore);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CanInteract = true;
            CurrentCoin = other.GetComponent<CoinBehaviour>();
            Debug.Log("Coin detected");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CanInteract = false;
            CurrentCoin = null;
            Debug.Log("Coin lost");
        }
    }
}
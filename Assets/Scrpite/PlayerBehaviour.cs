using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using StarterAssets;

public class PlayerBehaviour : MonoBehaviour
{
    float CurrentHealth = 100f;
    float RayLength = 5f;
    int CurrentScore = 0;
    bool CanInteract = false;
    CoinBehaviour CurrentCoin = null;
    BluePill CurrentBluePill = null;
    RedPill CurrentRedPill = null;
    Treasure CurrentTreasure = null;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Transform playerSpawnPoint;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Win;



    // Add these fields
    private Renderer lastRenderer = null;
    private Color originalColor;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerSpawnPoint.position, playerSpawnPoint.forward, out hit, RayLength))
        {

            // Only highlight if the tag matches a collectable
            if (hit.collider.CompareTag("Coin") || hit.collider.CompareTag("BluePill") || hit.collider.CompareTag("RedPill") || hit.collider.CompareTag("Treasure"))
            {
                // Highlight the object
                if (lastRenderer != null && lastRenderer != hit.collider.GetComponent<Renderer>())
                {
                    lastRenderer.material.color = originalColor; // Reset previous object's color
                }

                Renderer rend = hit.collider.GetComponent<Renderer>();
                if (rend != null)
                {
                    if (lastRenderer != rend)
                    {
                        lastRenderer = rend;
                        originalColor = rend.material.color;
                        rend.material.color = Color.yellow; // Highlight color
                    }
                }
            }
            else if (lastRenderer != null)
            {
                Renderer rend = hit.collider.GetComponent<Renderer>();
                if (rend != null)
                {
                    if (lastRenderer != rend)
                    {
                        if (lastRenderer != null)
                            lastRenderer.material.color = originalColor;

                        lastRenderer = rend;
                        originalColor = rend.material.color;
                        rend.material.color = Color.yellow; // Highlight color
                    }
                }
            }
            else if (lastRenderer != null)
            {
                lastRenderer.material.color = originalColor;
                lastRenderer = null;
            }

            // Set interactable references as before
            if (hit.collider.CompareTag("Coin"))
            {
                CanInteract = true;
                CurrentCoin = hit.collider.GetComponent<CoinBehaviour>();
                CurrentBluePill = null;
                CurrentRedPill = null;
            }
            else if (hit.collider.CompareTag("BluePill"))
            {
                CanInteract = true;
                CurrentBluePill = hit.collider.GetComponent<BluePill>();
                CurrentCoin = null;
                CurrentRedPill = null;
            }
            else if (hit.collider.CompareTag("RedPill"))
            {
                CanInteract = true;
                CurrentRedPill = hit.collider.GetComponent<RedPill>();
                CurrentCoin = null;
                CurrentBluePill = null;
            }
            else if (hit.collider.CompareTag("Treasure"))
            {
                CanInteract = true;
                CurrentTreasure = hit.collider.GetComponent<Treasure>();
                CurrentCoin = null;
                CurrentBluePill = null;
                CurrentRedPill = null;
            }
            else
            {
                CanInteract = false;
                CurrentCoin = null;
                CurrentBluePill = null;
                CurrentRedPill = null;
            }
        }
        else
        {
            if (lastRenderer != null)
            {
                lastRenderer.material.color = originalColor;
                lastRenderer = null;
            }
            CanInteract = false;
            CurrentCoin = null;
            CurrentBluePill = null;
            CurrentRedPill = null;
        }
    }
    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            healthText.text = CurrentHealth.ToString();
            Debug.Log("Player is dead");
            Lose.SetActive(true);


        }
        else
        {
            healthText.text = CurrentHealth.ToString();
        }
    }

    void OnInteract()
    {
        if (CanInteract && CurrentCoin != null)
        {
            Debug.Log("Interacting with coin");
            CurrentCoin.Collect(this);
        }
        else if (CanInteract && CurrentBluePill != null)
        {
            Debug.Log("Interacting with blue pill");
            CurrentBluePill.Collect(this);
        }
        else if (CanInteract && CurrentRedPill != null)
        {
            Debug.Log("Interacting with red pill");
            CurrentRedPill.Collect(this);
        }
        else if (CanInteract && CurrentTreasure != null)
        {
            Debug.Log("Interacting with treasure");
            CurrentTreasure.Collect(this);
            Win.SetActive(true);

        }
        else
        {
            Debug.Log("No interactable object in range");
        }
    }

    public void ModifyScore(int amount)
    {
        CurrentScore += amount;
        scoreText.text = CurrentScore.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CanInteract = true;
            CurrentCoin = other.GetComponent<CoinBehaviour>();
            Debug.Log("Coin detected");
        }
        else if (other.CompareTag("BluePill"))
        {
            CanInteract = true;
            CurrentBluePill = other.GetComponent<BluePill>();
            Debug.Log("Blue pill detected");
        }
        else if (other.CompareTag("RedPill"))
        {
            CanInteract = true;
            CurrentRedPill = other.GetComponent<RedPill>();
            Debug.Log("Red pill detected");
        }
        else if (other.CompareTag("Treasure"))
        {
            CanInteract = true;
            CurrentTreasure = other.GetComponent<Treasure>();
            Debug.Log("Treasure detected");
            // Optionally, you can add logic to handle what happens when the treasure is found
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
        else if (other.CompareTag("BluePill"))
        {
            CanInteract = false;
            CurrentBluePill = null;
            Debug.Log("Blue pill lost");
        }
        else if (other.CompareTag("RedPill"))
        {
            CanInteract = false;
            CurrentRedPill = null;
            Debug.Log("Red pill lost");

        }
        else if (other.CompareTag("Treasure"))
        {
            CanInteract = false;
            CurrentTreasure = null;
            // Optionally, you can add logic to handle what happens when the treasure is found
        }
    }
    void SpawnPoint()
    {
        gameObject.transform.position = playerSpawnPoint.position;
        Physics.SyncTransforms();
    }

}

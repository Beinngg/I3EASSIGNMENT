/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: PLAYER BEHAVIOUR AND INTERACTION WITH COLLECTABLES
*/
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
// using StarterAssets; // Only needed if you use StarterAssetsInput

public class PlayerBehaviour : MonoBehaviour
{
    float CurrentHealth = 100f; // Player's health
    float RayLength = 5f; // Raycast length for interaction
    int CurrentScore = 0; // Player's score
    bool CanInteract = false; // Can the player interact with something?
    CoinBehaviour CurrentCoin = null; // Reference to coin in range
    BluePill CurrentBluePill = null; // Reference to blue pill in range
    RedPill CurrentRedPill = null; // Reference to red pill in range
    Treasure CurrentTreasure = null; // Reference to treasure in range
    [SerializeField] TMP_Text scoreText; // UI text for score
    [SerializeField] TMP_Text healthText; // UI text for health
    [SerializeField] Transform playerSpawnPoint; // Where to respawn the player
    [SerializeField] GameObject Lose; // Lose screen
    [SerializeField] GameObject Win; // Win screen

    private Renderer lastRenderer = null; // Last highlighted object's renderer
    private Color originalColor; // Original color of last highlighted object

    void Update()
    {
        // Raycast forward from the player to detect interactables
        RaycastHit hit;
        if (Physics.Raycast(playerSpawnPoint.position, playerSpawnPoint.forward, out hit, RayLength))
        {
            // Highlight collectable objects
            if (hit.collider.CompareTag("Coin") || hit.collider.CompareTag("BluePill") || hit.collider.CompareTag("RedPill") || hit.collider.CompareTag("Treasure"))
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

            // Set interactable references based on what was hit
            if (hit.collider.CompareTag("Coin"))
            {
                CanInteract = true;
                CurrentCoin = hit.collider.GetComponent<CoinBehaviour>();
                CurrentBluePill = null;
                CurrentRedPill = null;
                CurrentTreasure = null;
            }
            else if (hit.collider.CompareTag("BluePill"))
            {
                CanInteract = true;
                CurrentBluePill = hit.collider.GetComponent<BluePill>();
                CurrentCoin = null;
                CurrentRedPill = null;
                CurrentTreasure = null;
            }
            else if (hit.collider.CompareTag("RedPill"))
            {
                CanInteract = true;
                CurrentRedPill = hit.collider.GetComponent<RedPill>();
                CurrentCoin = null;
                CurrentBluePill = null;
                CurrentTreasure = null;
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
                CurrentTreasure = null;
            }
        }
        else
        {
            // Reset highlight and references if nothing is hit
            if (lastRenderer != null)
            {
                lastRenderer.material.color = originalColor;
                lastRenderer = null;
            }
            CanInteract = false;
            CurrentCoin = null;
            CurrentBluePill = null;
            CurrentRedPill = null;
            CurrentTreasure = null;
        }
    }

    public void ModifyHealth(float amount)
    {
        // Change player's health and update UI
        CurrentHealth += amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            healthText.text = CurrentHealth.ToString();
            Debug.Log("Player is dead");
            Lose.SetActive(true); // Show lose screen
        }
        else
        {
            healthText.text = CurrentHealth.ToString();
        }
    }

    void OnInteract()
    {
        // Called when player tries to interact (e.g., presses E)
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
            Win.SetActive(true); // Show win screen
        }
        else
        {
            Debug.Log("No interactable object in range");
        }
    }

    public void ModifyScore(int amount)
    {
        // Change player's score and update UI
        CurrentScore += amount;
        scoreText.text = CurrentScore.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        // Detect when player enters a trigger zone for an interactable
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
        // Reset references when player leaves a trigger zone
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
        // Move player to spawn point
        gameObject.transform.position = playerSpawnPoint.position;
        Physics.SyncTransforms();
    }
}
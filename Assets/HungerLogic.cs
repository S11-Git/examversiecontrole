using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerLogic : MonoBehaviour
{
    // Public hunger variable with a range from 0 to infinity (no upper bound)
    [Range(0, float.MaxValue)]
    public float hunger = 100f;

    // Base rate at which hunger decreases per second
    public float baseHungerDecreaseRate = 0.5f;

    // Rate at which hunger decreases per second when Shift is held down
    public float doubledHungerDecreaseRate = 1f;

    // Optional: Thresholds for specific actions based on hunger level
    public float extremelyHungryThreshold = 0f;
    public float gettingHungryThreshold = 25f;

    [SerializeField]
    private Text hungerText; // Reference to the Text object

    // Update is called once per frame
    void Update()
    {
        // Get the current hunger decrease rate based on whether Shift is held down
        float currentHungerDecreaseRate = Input.GetKey(KeyCode.LeftShift) ? doubledHungerDecreaseRate : baseHungerDecreaseRate;

        // Decrease hunger over time
        DecreaseHungerOverTime(currentHungerDecreaseRate);

        // Optional: Add additional logic based on hunger thresholds
        HandleHungerThresholds();

        // Update the hunger text
        UpdateHungerText();
    }

    private void UpdateHungerText()
    {
        if (hungerText != null)
        {
            hungerText.text = "Food: " + hunger.ToString("0");
        }
    }
    void DecreaseHungerOverTime(float decreaseRate)
    {
        // Decrease hunger gradually over time
        hunger -= decreaseRate * Time.deltaTime;

        // Check if hunger goes above 100 and reset it to 100
        if (hunger > 100f)
        {
            hunger = 100f;
        }
    }

    void HandleHungerThresholds()
    {
        // Optional: Add your logic for when hunger reaches certain thresholds
        if (hunger <= extremelyHungryThreshold)
        {
            // Player is extremely hungry, perform specific actions
            Debug.Log("Player is extremely hungry!");
        }
        else if (hunger < gettingHungryThreshold)
        {
            // Player is getting hungry, perform other actions
            Debug.Log("Player is getting hungry.");
        }

        if (hunger <= 0)
        {
            // Get a reference to the Health script
            Health playerHealth = GetComponent<Health>();

            // Check if the Health component is attached
            if (playerHealth != null)
            {
                playerHealth.deathCount++;

                // Update health and death count text
                playerHealth.UpdateHealthText();
                playerHealth.UpdateDeathCountText();
            }
            else
            {
                Debug.LogError("No Health component found on this GameObject.");
            }

            // Reset hunger to 100
            hunger = 100f;
        }


    }
}
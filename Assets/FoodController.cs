using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    // The amount of hunger to refill when the player eats the food
    public float hungerRefillAmount = 20f;

    // Reference to the object containing the HungerLogic script
    public HungerLogic hungerLogic;

    // Called every frame while the player is in the trigger zone
    private void OnTriggerStay(Collider other)
    {
        // Check if the object in the trigger is the player and holds down the "E" key
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && hungerLogic != null && hungerLogic.hunger < 100f)
        {
            // Refill the player's hunger
            hungerLogic.hunger += hungerRefillAmount;

            // Clamp the hunger to ensure it stays within the range 0 to 100
            hungerLogic.hunger = Mathf.Clamp(hungerLogic.hunger, 0f, 100f);

            // Optionally, you can destroy the food item after the player eats it
            Destroy(gameObject);
        }
    }
}

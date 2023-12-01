using UnityEngine;
using System.Collections;

public class Cookables : MonoBehaviour
{
    public CookingScript cookingScript; // Assign the CookingScript in the editor
    private bool steakActive = true; // Keep track of the steak's active state

    private void OnTriggerStay(Collider other)
    {
        // Check if the player entered the trigger area
        if (other.CompareTag("Player"))
        {
            // Check if the CookingScript is assigned
            if (cookingScript != null)
            {
                    // Display a message or perform any other desired action
                    Debug.Log("Player entered the trigger. Press 'G' to add meat.");

                    // Optionally, you can display a UI prompt to inform the player to press 'G'

                    // Assuming the player presses 'G' to add meat
                    if (Input.GetKey(KeyCode.E))
                    {
                        // Set HasMeat to true in the CookingScript
                        cookingScript.HasMeat = true;
                        RespawnSteak();
                        // Display a message or perform any other desired action
                        Debug.Log("Meat added to the CookingScript!");
                    }
            }
            else
            {
                // Display a message or perform any other desired action
                Debug.LogWarning("CookingScript is not assigned. Please assign it in the editor.");
            }
        }
    }

    private void RespawnSteak()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class CookingScript : MonoBehaviour
{
    public bool HasMeat = false; 
    public bool HasCookedMeat = false;
    public FirePlaceLogic firePlaceLogic; // Assign the FirePlaceLogic script in the editor
    public HungerLogic hungerLogic; // Assign the HungerLogic script in the editor
    public GameObject steak; // Reference to the "steak" GameObject
    public GameObject cookedSteak; // Reference to the "cookedSteak" GameObject

    private bool isCooking = false;

    void Update()
    {
        // Check if the player is in the fireplace trigger area, has steak and pressed 'C'
        if (HasMeat && firePlaceLogic.IsFireOn && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(CookingTime());
            steak.SetActive(true);
            Debug.Log("C was pressed");
            HasMeat = false; // The player has placed the meat on the fire
        }

        // Check if the player has cooked meat and pressed 'G'
        if (HasCookedMeat && hungerLogic != null && Input.GetKeyDown(KeyCode.G))
        {
            // Add 60 to the hunger variable in HungerLogic
            hungerLogic.hunger += 60f;
            HasCookedMeat = false; // The player has consumed the cooked meat
            cookedSteak.SetActive(false); // Hide the cooked steak
        }
    }

    IEnumerator CookingTime()
    {
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        HasCookedMeat = true; // The player now has cooked meat
        steak.SetActive(false); // Hide the raw steak
        cookedSteak.SetActive(true); // Show the cooked steak
    }
}
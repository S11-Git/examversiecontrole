using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    private AudioSource damageSound;

    [SerializeField]
    private Text healthText; // Reference to the Text object

    [SerializeField]
    private Text deathCountText; // Reference to the Text object for death count

    public int deathCount = 0; // Counter for player deaths

    // Declare a variable to store the initial position
    private Vector3 initialPosition;

    // Reference to the HungerLogic script
    public HungerLogic hungerLogic;

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
        UpdateHealthText();
        UpdateDeathCountText();
        // Store the initial position
        initialPosition = GetComponent<Rigidbody>().position;
    }

    // Public method to take damage from other scripts
    public void TakeDamage(float damageAmount)
    {
        // Play the damage sound if assigned
        if (damageSound != null)
        {
            damageSound.Play();
        }

        // Reduce health by the damage amount
        currentHealth -= damageAmount;
        UpdateHealthText();

        // Check if health is less than or equal to zero
        if (currentHealth <= 0)
        {
            // Call the Die method when health is zero or below
            Die();
        }
    }

    // Method to update the health text
    public void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    // Method to handle death
    private void Die()
    {
        // Perform actions when the GameObject dies
        Debug.Log(gameObject.name + " has died.");

        // Increment the death count
        deathCount++;
        UpdateDeathCountText();
        // Reset the player's position
        GetComponent<Rigidbody>().position = initialPosition;

        // Check if the player has reached the maximum allowed deaths
        if (deathCount >= 3)
        {
            // Reset the game by loading the main menu scene
            LoadMainMenu();
        }
        else
        {
            // Reset the player's health for the next attempt
            currentHealth = maxHealth;
            UpdateHealthText();
        }

        // Reset the player's hunger
        if (hungerLogic != null)
        {
            hungerLogic.hunger = 100f;
            
        }
    }

    // Method to update the death count text
    public void UpdateDeathCountText()
    {
        if (deathCountText != null)
        {
            deathCountText.text = "Deaths: " + deathCount.ToString();
        }
    }

    // Public method to reload the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // Replace "Menu" with the actual name of your main menu scene
    }

    // Method to heal the GameObject
    public void Heal(float healAmount)
    {
        // Increase health by the heal amount
        currentHealth += healAmount;

        // Clamp health to the maximum value
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    // Getter for current health
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Getter for max health
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    void LateUpdate()
    {
        // Check if health is less than 0
        if (currentHealth < 0)
        {
            // Reset health to 100
            currentHealth = 100f;

            // Increment death count
            deathCount++;

            // Update health and death count text
            UpdateHealthText();
            UpdateDeathCountText();
        }
    }
}

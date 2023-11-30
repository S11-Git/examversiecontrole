using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    public float currentHealth;

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
    }

    // Public method to take damage from other scripts
    public void TakeDamage(float damageAmount)
    {
        // Reduce health by the damage amount
        currentHealth -= damageAmount;

        // Check if health is less than or equal to zero
        if (currentHealth <= 0)
        {
            // Call the Die method when health is zero or below
            Die();
        }
    }

    // Method to handle death
    private void Die()
    {
        // Perform actions when the GameObject dies
        Debug.Log(gameObject.name + " has died.");

        Destroy(gameObject);
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
}

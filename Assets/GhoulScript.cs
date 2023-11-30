using UnityEngine;

public class GhoulScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ghoul1;

    [SerializeField]
    private GameObject ghoul2;

    [SerializeField]
    private float damageAmount = 10f;

    [SerializeField]
    private Health playerHealth; // Reference to the Health script on the player

    private bool isGhoul1Active = true;
    private bool isPlayerInTrigger = false;
    private float timeInTrigger = 0f;
    private bool hasDealtDamage = false;

    void Start()
    {
        // Enable ghoul1 by default
        EnableGhoul(ghoul1);

        // Assign the Health script from the player object
        playerHealth = FindObjectOfType<Health>();
        if (playerHealth == null)
        {
            Debug.LogError("Health script not found on the player object!");
        }
    }

    void Update()
    {
        // Check if the player is in the trigger zone
        if (isPlayerInTrigger)
        {
            // Increment the time in the trigger zone
            timeInTrigger += Time.deltaTime;

            // Check if the time in the trigger zone is greater than 2 seconds
            if (timeInTrigger > 2f && !hasDealtDamage)
            {
                // Toggle between ghoul1 and ghoul2 with a 1.8-second delay
                StartCoroutine(ToggleGhoulWithDelay());

                // Inflict damage to the player
                InflictDamageToPlayer();

                // Set the flag to indicate damage has been dealt
                hasDealtDamage = true;
            }
        }
        else
        {
            // Reset the time in trigger when the player is not in the trigger zone
            timeInTrigger = 0f;
        }
    }

    System.Collections.IEnumerator ToggleGhoulWithDelay()
    {
        // Disable ghoul1
        DisableGhoul(ghoul1);

        // Enable ghoul2
        EnableGhoul(ghoul2);

        // Wait for 1.8 seconds
        yield return new WaitForSeconds(1.8f);

        // Disable ghoul2
        DisableGhoul(ghoul2);

        // Enable ghoul1
        EnableGhoul(ghoul1);

        // Reset the flag to indicate damage can be dealt again
        hasDealtDamage = false;
    }

    void EnableGhoul(GameObject ghoul)
    {
        if (ghoul != null)
        {
            ghoul.SetActive(true);
        }
    }

    void DisableGhoul(GameObject ghoul)
    {
        if (ghoul != null)
        {
            ghoul.SetActive(false);
        }
    }

    // Check if the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    // Check if the player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    // Inflict damage to the player
    private void InflictDamageToPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}

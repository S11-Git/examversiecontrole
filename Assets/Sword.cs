using UnityEngine;

public class Sword : MonoBehaviour
{
    public float searchRadius = 2.0f; // Adjustable search radius
    private Animator animator;
    private bool animationPlaying = false;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0) && !animationPlaying)
        {
            // Enable the Animator
            animator.enabled = true;

            // Trigger the animation

            // Set a flag to indicate that the animation is playing
            animationPlaying = true;

            // Invoke a method to disable the Animator after 1 second
            Invoke("DisableAnimator", 1f);

            // Check for zombies within the search radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius);
            foreach (Collider hitCollider in hitColliders)
            {
                // Check if the collider has the "Zombie" tag
                if (hitCollider.CompareTag("Zombie"))
                {
                    // Deal damage to the zombie
                    NpcHealth npcHealth = hitCollider.GetComponent<NpcHealth>();
                    if (npcHealth != null)
                    {
                        npcHealth.TakeDamage(20f);
                    }
                }
            }
        }
    }

    // Method to disable the Animator
    void DisableAnimator()
    {
        // Disable the Animator
        animator.enabled = false;

        // Reset the flag
        animationPlaying = false;
    }
}

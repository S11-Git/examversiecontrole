using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public KeyCode teleportKey = KeyCode.Alpha1;

    // Assign the player GameObject and teleport destination in the editor
    public GameObject player;
    public Vector3 teleportDestination = new Vector3(-3.618f, -32.235f, -101.93f);

    private Rigidbody playerRigidbody;
    private bool playerInsideCollider = false;

    void Start()
    {
        if (player != null)
        {
            // Get the Rigidbody component from the assigned player GameObject
            playerRigidbody = player.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned in the editor.");
        }
    }

    void Update()
    {
        // Check if the player presses the specified key and is inside the collider
        if (Input.GetKeyDown(teleportKey) && playerInsideCollider)
        {
            // Teleport the player to the destination
            TeleportPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering GameObject is the player
        if (other.gameObject == player)
        {
            playerInsideCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting GameObject is the player
        if (other.gameObject == player)
        {
            playerInsideCollider = false;
        }
    }

    void TeleportPlayer()
    {
        if (playerRigidbody != null)
        {
            // Set the player's position to the teleport destination
            playerRigidbody.MovePosition(teleportDestination);
        }
    }
}

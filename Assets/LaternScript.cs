using UnityEngine;

public class LanternScript : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToToggle;

    [SerializeField]
    private KeyCode toggleKey = KeyCode.F;

    private void Update()
    {
        // Check if the assigned key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            // Toggle the visibility of the object
            if (objectToToggle != null)
            {
                objectToToggle.SetActive(!objectToToggle.activeSelf);
            }
            else
            {
                Debug.LogError("Object to toggle is not assigned!");
            }
        }
    }
}

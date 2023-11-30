using UnityEngine;

public class FirePlaceLogic : MonoBehaviour
{
    public bool HasWood = false;
    public bool IsFireOn = false;

    [SerializeField]
    private Transform woodPileTransform;

    [SerializeField]
    private Transform fireEffectTransform;

    [SerializeField]
    private Light fireLight;  // Add a serialized field for the light bulb

    void Start()
    {
        // Check if the assigned child objects exist
        if (woodPileTransform != null && fireEffectTransform != null && fireLight != null)
        {
            // Use Invoke to disable the child objects after 5 seconds
            Invoke("DisableFireObjects", 30f);
        }
        else
        {
            Debug.LogWarning("Child objects 'woodPileTransform', 'fireEffectTransform', or 'fireLight' not assigned.");
        }
    }

    void DisableFireObjects()
    {
        // Disable the assigned child objects
        if (woodPileTransform != null)
            woodPileTransform.gameObject.SetActive(false);

        if (fireEffectTransform != null)
            fireEffectTransform.gameObject.SetActive(false);

        // Disable the light bulb
        if (fireLight != null)
            fireLight.gameObject.SetActive(false);

        // Fire is no longer on
        IsFireOn = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (HasWood == true && IsFireOn == false)
        {
            // check if the player presses E key; if they do, then start the fire
            if (Input.GetKey(KeyCode.E))
            {
                StartFire();
            }
        }
    }

    void StartFire()
    {
        // Enable the assigned child objects
        if (woodPileTransform != null)
            woodPileTransform.gameObject.SetActive(true);

        if (fireEffectTransform != null)
            fireEffectTransform.gameObject.SetActive(true);

        // Enable the light bulb
        if (fireLight != null)
            fireLight.gameObject.SetActive(true);

        // restart timer
        Invoke("DisableFireObjects", 30f);
        // change bool HasWood to false 
        HasWood = false;

        // Fire is now on
        IsFireOn = true;
    }
}

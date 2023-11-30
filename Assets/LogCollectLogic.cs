using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCollectLogic : MonoBehaviour
{
    public GameObject fireplace; // Reference to the "fireplace" GameObject
    public GameObject stick1; // Reference to the "stick1" GameObject
    public GameObject stick2; // Reference
    public GameObject stick3; // Reference
    public GameObject stick4; // Reference

    // Update is called once per frame
    void Update()
    {
        // Update logic here if needed
    }

    void OnTriggerStay(Collider other)
    {
        // Check if player presses E key to start the fire
        if (Input.GetKey(KeyCode.E))
        {
            // check if HasWood is true
            if (fireplace.GetComponent<FirePlaceLogic>().HasWood == true)
            {
                // nothing happens
                return;
            }
            else
            {
                // collect log
                CollectLog();
            }
            
        }
    }

    void CollectLog()
    {
        
        FirePlaceLogic firePlaceLogic = fireplace.GetComponent<FirePlaceLogic>();
        // Change the bool in FirePlaceLogic to indicate that wood is collected
        firePlaceLogic.HasWood = true;

        // Disable stick1 for 60 seconds
        StartCoroutine(DisableStickForSeconds(stick1, 6));
        StartCoroutine(DisableStickForSeconds(stick2, 6));
        StartCoroutine(DisableStickForSeconds(stick3, 6));
        StartCoroutine(DisableStickForSeconds(stick4, 6));
    }

    IEnumerator DisableStickForSeconds(GameObject stick, float seconds)
    {
        // Disable the stick
        stick.SetActive(false);

        // Wait for the specified amount of seconds
        yield return new WaitForSeconds(seconds);

        // Enable the stick again
        stick.SetActive(true);
    }
}
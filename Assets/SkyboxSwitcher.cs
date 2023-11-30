using System.Collections;
using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public Light daySun;
    public Light nightMoon;

    // Time interval for transitioning between day and night (in seconds)
    public float transitionInterval = 10f;

    void Start()
    {
        // Start the coroutine to smoothly transition between day and night at regular intervals
        StartCoroutine(DayNightCycleRoutine());
    }

    IEnumerator DayNightCycleRoutine()
    {
        while (true)
        {
            // Transition to night
            yield return TransitionToNight();

            // Wait for the specified interval
            yield return new WaitForSeconds(transitionInterval);

            // Transition to day
            yield return TransitionToDay();

            // Wait for the specified interval
            yield return new WaitForSeconds(transitionInterval);
        }
    }

    IEnumerator TransitionToNight()
    {
        float elapsedTime = 0f;
        float duration = transitionInterval;

        while (elapsedTime < duration)
        {
            // Interpolate light intensity and color
            daySun.intensity = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            nightMoon.intensity = Mathf.Lerp(0f, 1f, elapsedTime / duration);

            // Optional: You can add more settings for the transition

            // Increment time
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the night skybox material
        RenderSettings.skybox = nightSkybox;
    }

    IEnumerator TransitionToDay()
    {
        float elapsedTime = 0f;
        float duration = transitionInterval;

        while (elapsedTime < duration)
        {
            // Interpolate light intensity and color
            daySun.intensity = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            nightMoon.intensity = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            // Optional: You can add more settings for the transition

            // Increment time
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the day skybox material
        RenderSettings.skybox = daySkybox;
    }
}

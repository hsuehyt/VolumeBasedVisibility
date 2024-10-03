using UnityEngine;

public class VolumeBasedVisibilityController : MonoBehaviour
{
    // Reference to the audio source and visual object
    public AudioSource audioSource;
    public GameObject visualObject;

    // The volume threshold in dB, default is -10 dB
    public float volumeThresholdDB = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the visual object is off at the start
        visualObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current audio level in dB
        float currentVolumeDB = GetCurrentVolumeInDB();

        // Compare the current volume in dB to the threshold
        if (currentVolumeDB >= volumeThresholdDB)
        {
            // Turn on the visual object if volume exceeds the threshold
            visualObject.SetActive(true);
        }
        else
        {
            // Turn off the visual object if volume is below the threshold
            visualObject.SetActive(false);
        }
    }

    // Method to set the threshold in dB externally
    public void SetVolumeThresholdDB(float newThresholdDB)
    {
        volumeThresholdDB = newThresholdDB;
    }

    // Helper method to get the current volume in dB from the AudioSource
    private float GetCurrentVolumeInDB()
    {
        // Create a buffer to store audio samples
        float[] samples = new float[256];

        // Get audio samples from the audio source (range -1.0 to 1.0)
        audioSource.GetOutputData(samples, 0);

        // Compute the RMS (Root Mean Square) volume level of the audio samples
        float sum = 0f;
        foreach (float sample in samples)
        {
            sum += sample * sample;
        }
        float rmsValue = Mathf.Sqrt(sum / samples.Length);

        // Convert RMS to decibels (dB)
        float dbValue = 20 * Mathf.Log10(rmsValue);

        // If the dB value is too low (logarithmic values can be extremely negative), clamp it to a low value
        if (float.IsNegativeInfinity(dbValue))
        {
            dbValue = -80f; // Minimum value, can be adjusted based on your needs
        }

        return dbValue;
    }
}

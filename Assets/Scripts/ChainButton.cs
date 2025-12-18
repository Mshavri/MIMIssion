using UnityEngine;
using UnityEngine.UI;

// Makes any button play a sound when clicked
[RequireComponent(typeof(Button))]      // Ensures a Button component exists
[RequireComponent(typeof(AudioSource))] // Ensures an AudioSource component exists
public class ChainButton : MonoBehaviour
{
    private Button button;           // Button reference
    private AudioSource audioSource; // Audio source to play sound

    void Awake()
    {
        // Get components from the same object
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        // Play sound when button is clicked
        button.onClick.AddListener(PlaySound);

        // Disable auto play and looping
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void PlaySound()
    {
        // Play sound if a clip is assigned
        if (audioSource.clip)
            audioSource.Play();
    }
}

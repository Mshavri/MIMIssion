using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class ChainButton : MonoBehaviour
{
    private Button button;
    private AudioSource audioSource;

    void Awake()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        button.onClick.AddListener(PlaySound);

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void PlaySound()
    {
        if (audioSource.clip != null)
            audioSource.Play();
        else
            Debug.LogWarning("No audio clip assigned to " + gameObject.name);
    }
}

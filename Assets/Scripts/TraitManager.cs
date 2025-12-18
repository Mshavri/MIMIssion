using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Allows scene switching

public class TraitManager : MonoBehaviour
{
    public static TraitManager Instance;

    public TextMeshProUGUI traitText;
    public AudioSource audioSource;
    public AudioClip traitSound;

    public int currentTraits = 0;
    public int maxTraits = 3;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateTraitUI();
    }

    public void AddTrait(int amount = 1)
    {
        currentTraits += amount;

        if (currentTraits > maxTraits)
            currentTraits = maxTraits;

        UpdateTraitUI();
        PlayTraitSound();

        // Check if player reached the required amount
        if (currentTraits >= maxTraits)
        {
            SceneManager.LoadScene("end"); // Load end scene
        }
    }

    void UpdateTraitUI()
    {
        traitText.text = currentTraits + "/" + maxTraits;
    }

    void PlayTraitSound()
    {
        if (audioSource != null && traitSound != null)
        {
            audioSource.PlayOneShot(traitSound);
        }
    }
}

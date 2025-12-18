using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;
    private AudioSource audioSource;
    private float targetVolume;     // Target volume level
    private float originalVolume;   // Stored original volume
    public float fadeSpeed = 0.5f;  // Fade speed

    void Awake()
    {
        // Ensure only one music instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            // Store volume set in Inspector
            originalVolume = audioSource.volume;
            targetVolume = originalVolume;

            // Listen for scene changes
            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from scene change event
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    void Update()
    {
        // Smooth volume transition
        if (audioSource != null && Mathf.Abs(audioSource.volume - targetVolume) > 0.01f)
        {
            audioSource.volume = Mathf.MoveTowards(
                audioSource.volume,
                targetVolume,
                fadeSpeed * Time.deltaTime
            );
        }
    }

    void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        // Lower volume in LevelOne scene
        if (newScene.name == "LevelOne")
            targetVolume = originalVolume * 0.5f;
        else
            targetVolume = originalVolume; // Restore original volume
    }
}

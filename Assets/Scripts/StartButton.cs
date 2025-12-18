using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Simple start button script with sound, fade, and scene load
public class StartButton : MonoBehaviour
{
    public Button button;            // Start button
    public Image fadeImage;          // Fade image
    public AudioSource clickSound;   // Button click sound
    public string sceneToLoad = "characterscene"; // Scene name
    public float fadeDuration = 1f;  // Fade time in seconds

    void Start()
    {
        // Get Button component if not assigned
        if (button == null)
            button = GetComponent<Button>();

        // Start with transparent fade image
        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);

        // Register click event
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // Play click sound
        if (clickSound != null)
            clickSound.Play();

        // Start fade and load scene
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(sceneToLoad); // Load directly if no fade
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        Color color = fadeImage.color;
        float t = 0f;

        // Fade screen to black
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Load new scene after fade
        SceneManager.LoadScene(sceneToLoad);
    }
}

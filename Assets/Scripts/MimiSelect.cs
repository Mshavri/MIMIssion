using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Used when the player selects the Mimi character
public class MimiSelect : MonoBehaviour
{
    public Image fadeImage;               // Fade image that covers the screen
    public float fadeDuration = 1f;       // Fade time
    public string nextScene = "LevelOne"; // Scene to load

    public void OnClickMimi()
    {
        // Save selected character
        PlayerPrefs.SetString("SelectedCharacter", "Mimi");

        // Start fade and scene load
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(nextScene); // Load directly if no fade
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        Color color = fadeImage.color;
        float t = 0f;

        // Increase alpha until screen is fully black
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Load next scene after fade completes
        SceneManager.LoadScene(nextScene);
    }
}

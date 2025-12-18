using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Fades the screen from black to transparent when the scene starts
public class SceneFadeIn : MonoBehaviour
{
    public Image fadeImage;          // Fade image covering the screen
    public float fadeDuration = 1f;  // Fade time
    public float startDelay = 1f;    // Optional delay before fade starts

    void Start()
    {
        if (fadeImage != null)
        {
            // Start with a fully black screen
            Color color = fadeImage.color;
            color.a = 1f;
            fadeImage.color = color;

            // Start fade coroutine
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        // Wait before starting the fade
        yield return new WaitForSeconds(startDelay);

        Color color = fadeImage.color;
        float t = 0f;

        // Gradually fade to transparent
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Ensure alpha reaches zero
        color.a = 0f;
        fadeImage.color = color;
    }
}

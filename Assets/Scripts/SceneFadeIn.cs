using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFadeIn : MonoBehaviour
{
    public Image fadeImage;         // صورة الفيد
    public float fadeDuration = 1f; // مدة الفيد (ثواني)
    public float startDelay = 0.2f; // تأخير قبل بدء الفيد (اختياري)

    void Start()
    {
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 1f; // يبدأ أسود
            fadeImage.color = color;

            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(startDelay);

        Color color = fadeImage.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
    }
}

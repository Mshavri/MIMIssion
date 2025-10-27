using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// سكربت يخلي الشاشة تسوي تلاشي من الأسود إلى الشفافية لما يبدأ المشهد
public class SceneFadeIn : MonoBehaviour
{
    public Image fadeImage;          // صورة الفيد (اللي تغطي الشاشة)
    public float fadeDuration = 1f;  // كم ياخذ وقت التلاشي
    public float startDelay = 1f;    // وقت انتظار قبل يبدأ الفيد (اختياري)

    void Start()
    {
        if (fadeImage != null)
        {
            // نخلي الشاشة سوداء بالبداية
            Color color = fadeImage.color;
            color.a = 1f;
            fadeImage.color = color;

            // نبدأ كروتين التلاشي
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        // ننتظر شوي قبل يبدأ الفيد (لو فيه تأخير)
        yield return new WaitForSeconds(startDelay);

        Color color = fadeImage.color;
        float t = 0f;

        // نخفف السواد بالتدريج إلى أن تصير الشاشة شفافة تمامًا
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadeImage.color = color;
            yield return null; // نكمل بالفريم الجاي
        }

        // نتأكد إن الشفافية وصلت للصفر
        color.a = 0f;
        fadeImage.color = color;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// هذا السكربت يستخدم لما اللاعب يختار شخصية "Mimi"
public class MimiSelect : MonoBehaviour
{
    public Image fadeImage;          // صورة الفيد (الأسود اللي يغطي الشاشة)
    public float fadeDuration = 1f;  // كم ياخذ وقت الفيد
    public string nextScene = "LevelOne"; // اسم المشهد اللي بننتقل له

    public void OnClickMimi()
    {
        // نحفظ اسم الشخصية المختارة (لو بنحتاجها بعدين)
        PlayerPrefs.SetString("SelectedCharacter", "Mimi");

        // نسوي تلاشي وانتقال للمشهد الجديد
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(nextScene); // لو ما فيه فيد، نحمل المشهد مباشرة
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        Color color = fadeImage.color;
        float t = 0f;

        // نرفع الشفافية تدريجياً إلى أن تصير الشاشة سوداء بالكامل
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // بعد ما يصير الفيد كامل، ننتقل للمشهد التالي
        SceneManager.LoadScene(nextScene);
    }
}

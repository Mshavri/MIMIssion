using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MimiSelect : MonoBehaviour
{
    public Image fadeImage;         // صورة الفيد الأسود
    public float fadeDuration = 1f; // مدة الفيد
    public string nextScene = "LevelOne"; // المشهد التالي

    public void OnClickMimi()
    {
        // حفظ اسم الشخصية (اختياري لو تحتاجه في المستقبل)
        PlayerPrefs.SetString("SelectedCharacter", "Mimi");

        // انتقال بالمؤثر
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(nextScene);
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        Color color = fadeImage.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}

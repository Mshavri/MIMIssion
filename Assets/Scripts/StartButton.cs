using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// سكربت بسيط لزر البداية: يشغل صوت، يسوي فيد، ويدخل للمشهد الجديد
public class StartButton : MonoBehaviour
{
    public Button button;            // زر البداية
    public Image fadeImage;          // صورة الفيد (التلاشي)
    public AudioSource clickSound;   // صوت الضغط على الزر
    public string sceneToLoad = "characterscene"; // اسم المشهد اللي بنروح له
    public float fadeDuration = 1f;  // مدة الفيد بالثواني

    void Start()
    {
        // لو الزر ما تعين من الانسبكتر، نجيبه من نفس الأوبجكت
        if (button == null)
            button = GetComponent<Button>();

        // نخلي الفيد شفاف بالبداية
        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);

        // نخلي الزر يشغل دالة OnClick لما ينضغط
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // نشغل الصوت لو موجود
        if (clickSound != null)
            clickSound.Play();

        // نسوي الفيد وننتقل للمشهد الجديد
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(sceneToLoad); // لو ما فيه فيد، نحمل المشهد مباشرة
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        Color color = fadeImage.color;
        float t = 0f;

        // نخلي الشاشة تصير سودة بالتدريج
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null; // ننتظر فريم
        }

        // بعد ما يصير الفيد كامل، نبدل للمشهد الجديد
        SceneManager.LoadScene(sceneToLoad);
    }
}

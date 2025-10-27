using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// هذا السكربت يخلي الزر يشغل صوت + تلاشي + ينقل لمشهد جديد
public class CharButton : MonoBehaviour
{
    public Button button;           // الزر اللي يضغط عليه اللاعب
    public Image fadeImage;         // صورة التلاشي (الفيد)
    public AudioSource clickSound;  // صوت الضغط
    public string sceneToLoad = "characterscene"; // اسم المشهد اللي نبي نروح له
    public float fadeDuration = 1f; // مدة التلاشي

    void Start()
    {
        // لو الزر ما تعين من الانسبكتر، نجيبه من نفس الأوبجكت
        if (button == null)
            button = GetComponent<Button>();

        // نضبط لون الفيد بالبداية يكون شفاف تماماً
        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);

        // نخلي الزر ينفذ دالة OnClick لما ينضغط
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // نشغل صوت الضغط لو موجود
        if (clickSound != null)
            clickSound.Play();

        // لو فيه صورة للتلاشي، نسوي كروتين التلاشي
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            // لو ما فيه تلاشي، ننتقل للمشهد مباشرة
            SceneManager.LoadScene(sceneToLoad);
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        // نخزن لون الفيد ونبدأ نرفع الشفافية بالتدريج
        Color color = fadeImage.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration); // نزيد الشفافية
            fadeImage.color = color;
            yield return null; // ننتظر فريم
        }

        // بعد ما يخلص الفيد، نحمل المشهد الجديد
        SceneManager.LoadScene(sceneToLoad);
    }
}

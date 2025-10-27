using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;
    private AudioSource audioSource;
    private float targetVolume;     // المستوى اللي بننتقل له
    private float originalVolume;   // نحفظ فيه الصوت الأصلي
    public float fadeSpeed = 0.5f;  // سرعة الفيد (ثابتة مثل ما تبي)

    void Awake()
    {
        // نتأكد ان فيه نسخه وحده من الصوت بكل اللعبه
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            // نحفظ الصوت اللي انت حاطه بالانسبكتور
            originalVolume = audioSource.volume;
            targetVolume = originalVolume;

            // نسمع اذا تغير المشهد
            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // نفصل الحدث لو الكائن انحذف
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    void Update()
    {
        // يخلي الصوت يتغير شوي شوي بدون ما يطلع فوق اللي حاطه انت
        if (audioSource != null && Mathf.Abs(audioSource.volume - targetVolume) > 0.01f)
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, fadeSpeed * Time.deltaTime);
        }
    }

    void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        // اذا دخلت مشهد LevelOne ينقص الصوت للنص من اللي انت محدده
        if (newScene.name == "LevelOne")
            targetVolume = originalVolume * 0.5f;
        else
            targetVolume = originalVolume; // يرجع لنفس المستوى اللي كان عليه
    }
}

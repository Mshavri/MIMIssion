using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharButton : MonoBehaviour
{
    public Button button;           // زر الكراكتر
    public Image fadeImage;         // تأثير التلاشي
    public AudioSource clickSound;  // صوت الضغط
    public string sceneToLoad = "characterscene";
    public float fadeDuration = 1f; // مدة التلاشي

    void Start()
    {
        if (button == null)
            button = GetComponent<Button>();

        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (clickSound != null)
            clickSound.Play();

        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(sceneToLoad);
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

        SceneManager.LoadScene(sceneToLoad);
    }
}

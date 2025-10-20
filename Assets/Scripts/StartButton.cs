using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button button;           // start button
    public Image fadeImage;         // fade effect image
    public AudioSource clickSound;  // sound when button is clicked
    public string sceneToLoad = "characterscene"; // <-- المشهد الجديد
    public float fadeDuration = 1f; // fade time in seconds

    void Start()
    {
        // auto set button if not assigned
        if (button == null) button = GetComponent<Button>();

        // make fade image invisible at start
        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);

        // when button is clicked -> run OnClick()
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // play click sound if assigned
        if (clickSound != null)
            clickSound.Play();

        // run fade and load next scene
        if (fadeImage != null)
            StartCoroutine(FadeAndLoad());
        else
            SceneManager.LoadScene(sceneToLoad);
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        Color color = fadeImage.color;
        float t = 0f;

        // fade from clear to black
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // load next scene (characterscene)
        SceneManager.LoadScene(sceneToLoad);
    }
}

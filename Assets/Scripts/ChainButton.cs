using UnityEngine;
using UnityEngine.UI;

// هذا السكربت يخلي أي زر يشغل صوت لما نضغط عليه
[RequireComponent(typeof(Button))]      // يتأكد إن فيه Button على الأوبجكت
[RequireComponent(typeof(AudioSource))] // ويتأكد بعد إن فيه AudioSource
public class ChainButton : MonoBehaviour
{
    private Button button;           // الزر نفسه
    private AudioSource audioSource; // الصوت اللي بنشغله

    void Awake()
    {
        // نجيب المكونات من نفس الأوبجكت
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        // لما ينضغط الزر، يشغل الصوت
        button.onClick.AddListener(PlaySound);

        // نوقف التشغيل التلقائي والتكرار
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void PlaySound()
    {
        // لو فيه ملف صوتي، نشغله
        if (audioSource.clip)
            audioSource.Play();
    }
}

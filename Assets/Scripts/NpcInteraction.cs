using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject dialogueBox;
    public GameObject scrambledText;
    public GameObject clearText;
    public DadPuzzle dadPuzzle;

    private bool playerInRange;

    void Start()
    {
        // هذه الرسالة ستظهر في الكونسول إذا كان الكود الجديد يعمل
        Debug.Log(">>> الكود الجديد يعمل الآن! <<<");

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }

        // الحماية الثلاثية: هل المتغير موجود؟
        if (scrambledText != null)
        {
            scrambledText.SetActive(true);
        }
        else
        {
            // هذا السطر يمنع الخطأ ويخبرنا أن الخانة فارغة بشكل آمن
             Debug.Log("تنبيه: لا يوجد نص مشفر (هذا طبيعي للأب)");
        }

        if (clearText != null)
        {
            clearText.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);

                if (dadPuzzle == null)
                {
                    if (scrambledText != null) scrambledText.SetActive(true);
                    if (clearText != null) clearText.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(false);
            }
        }
    }
}
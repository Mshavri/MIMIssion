using UnityEngine;

public class SonMotherDia : MonoBehaviour
{
    // هذا هو كائن الخلفية (الصندوق) الذي يظهر ويختفي
    public GameObject dialogueBox;
    
    // هذا هو كائن المحادثة الفعلية التي ستظهر (نص/صورة المحادثة الوحيدة)
    public GameObject clearContent; 
    
    // تم إزالة scrambledText لأنه لم يعد ضروريًا.
    // تم الإبقاء على hasItem في حال احتجت إليه لاحقًا.
    private bool playerNearby = false;
    private bool hasItem = false; 

    void Start()
    {
        // تأكد من أن النص واضح (المحادثة الوحيدة) مفعل وأن الصندوق مخفي
        clearContent.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            // إخفاء الصندوق الرئيسي
            dialogueBox.SetActive(false);
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            // التبديل بين إظهار وإخفاء صندوق المحادثة
            dialogueBox.SetActive(!dialogueBox.activeSelf);
            
            // بما أن لديك محادثة واحدة فقط، لن نغير حالة clearContent.
            // clearContent سيبقى دائماً مفعلاً داخل dialogueBox.
        }
    }

    public void CollectItem()
    {
        hasItem = true;
        // يمكنك إضافة منطق هنا إذا أردت أن يؤدي جمع عنصر مهمة عند الأم/الابن
    }
}
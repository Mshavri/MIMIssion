using UnityEngine;

public class DoorController : MonoBehaviour
{
    // المتغير الثابت (Static) الذي سيعمل كـ "ذاكرة المفتاح"
    // يجب أن يكون اسمه مطابقاً تماماً
    public static bool IsKeyCollected = false;

    // متغير لتتبع ما إذا كان اللاعب في نطاق الكاشف (Trigger)
    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        // التحقق: اللاعب قريب + ضغط Space
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            // التحقق مباشرة من المتغير الثابت داخل نفس السكريبت
            if (IsKeyCollected)
            {
                // المفتاح موجود: تدمير الباب مباشرةً
                Destroy(gameObject);
                Debug.Log("تم تدمير الباب!");
            }
            else
            {
                Debug.Log("الباب مقفل. المفتاح مفقود!");
            }
        }
    }
}
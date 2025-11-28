using UnityEngine;

// هذا السكريبت يُرفق بكائن النظارة (Glasses GameObject)
public class GlassesPickup : MonoBehaviour
{
    // متغير عام (Public) لربط شخصية الأم به من محرر Unity
    public GameObject MotherNPC;

    // تُستدعى هذه الدالة عندما يتلامس اللاعب مع الـ Collider (بما أنه Trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // يجب أن يكون الـ Tag الخاص بكائن القطة/اللاعب هو "Player" ليعمل الشرط
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. تفعيل Mother NPC
            if (MotherNPC != null)
            {
                // SetActive(true) هي التي تجعل الكائن مرئياً ونشطاً في المشهد
                MotherNPC.SetActive(true);
                Debug.Log("Mother has appeared after picking up glasses!");
            }

            // 2. تدمير GameObject النظارة لجمعها من المشهد
            Destroy(gameObject);
        }
    }
}
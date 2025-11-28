using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. تفعيل المفتاح مباشرةً في ذاكرة الباب (باستخدام اسم الكلاس الثابت)
            DoorController.IsKeyCollected = true; 
            
            Debug.Log("المفتاح تم جمعه. تم تفعيل فتح الباب.");
            
            // 2. إزالة المفتاح من المشهد
            Destroy(gameObject);
        }
    }
}
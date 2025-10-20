using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;

    void Awake()
    {
        // تأكد أنه فيه نسخة وحدة فقط من هذا العنصر
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // يخليه ما ينحذف بين المشاهد
        }
        else
        {
            // إذا فيه نسخة ثانية (من مشهد آخر مثلاً) نحذفها
            Destroy(gameObject);
        }
    }
}

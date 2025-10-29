using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform player;        // اللاعب اللي بنزوم عليه
    public float targetZoom = 5f;   // الزوم اللي نبي نوصل له
    public float zoomDuration = 2f; // كم ياخذ وقت الزوم (بالثواني)
    public float followSpeed = 3f;  // سرعة متابعة اللاعب بعد الزوم

    private Camera cam;             
    private float zoomTimer;        // عداد الوقت للزوم
    private bool zooming = true;    // هل الحين قاعد يزوم ولا خلص
    private float startZoom;        // الزوم اللي بدأت فيه الكاميرا
    private Vector3 startPos;       // موقع الكاميرا بالبداية

    void Start()
    {
        cam = GetComponent<Camera>();        // نجيب الكاميرا اللي على نفس الأوبجكت
        startZoom = cam.orthographicSize;    // نخزن الزوم الحالي كبداية
        startPos = transform.position;       // نخزن موقع الكاميرا الحالي
    }

    void LateUpdate()
    {
        if (player == null) return; // لو اللاعب مو موجود، نطلع على طول

        if (zooming)
        {
            zoomTimer += Time.deltaTime;               // نزيد العداد مع الوقت
            float t = zoomTimer / zoomDuration;        // نحسب نسبة التقدم في الزوم (من 0 إلى 1)

            // نحرك الكاميرا باتجاه اللاعب بالتدريج
            Vector3 targetPos = new Vector3(player.position.x, player.position.y, startPos.z);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            // نغير الزوم بالتدريج من البداية للنهاية
            cam.orthographicSize = Mathf.Lerp(startZoom, targetZoom, t);

            // إذا خلص وقت الزوم نوقف
            if (zoomTimer >= zoomDuration)
                zooming = false;
        }
        else
        {
            // بعد ما يخلص الزوم، الكاميرا تتابع اللاعب بسلاسة
            Vector3 followPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followPos, followSpeed * Time.deltaTime);
        }
    }
}

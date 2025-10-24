using UnityEngine;

public class CameraZoomToPlayer : MonoBehaviour
{
    public Transform player;        // اللاعب
    public float targetZoom = 5f;   // الزوم النهائي
    public float zoomDuration = 2f; // مدة الزوم بالثواني
    public float followSpeed = 3f;  // سرعة متابعة اللاعب بعد الزوم

    private Camera cam;
    private float zoomTimer;
    private bool zooming = true;
    private float startZoom;
    private Vector3 startPos;

    void Start()
    {
        cam = GetComponent<Camera>();
        startZoom = cam.orthographicSize; // يأخذ الزوم الحالي كما هو
        startPos = transform.position;    // يحتفظ بموقع الكاميرا الحالي
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (zooming)
        {
            zoomTimer += Time.deltaTime;
            float t = zoomTimer / zoomDuration;

            // تقريب الكاميرا على اللاعب تدريجياً
            Vector3 targetPos = new Vector3(player.position.x, player.position.y, startPos.z);
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            cam.orthographicSize = Mathf.Lerp(startZoom, targetZoom, t);

            if (zoomTimer >= zoomDuration)
                zooming = false;
        }
        else
        {
            // بعد انتهاء الزوم: تتبع اللاعب بسلاسة
            Vector3 followPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followPos, followSpeed * Time.deltaTime);
        }
    }
}

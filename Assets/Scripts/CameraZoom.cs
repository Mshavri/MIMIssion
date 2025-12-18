using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform player;        // Player to zoom toward
    public float targetZoom = 5f;   // Target zoom value
    public float zoomDuration = 2f; // Zoom time in seconds
    public float followSpeed = 3f;  // Camera follow speed after zoom

    private Camera cam;
    private float zoomTimer;        // Zoom timer
    private bool zooming = true;    // Zoom state
    private float startZoom;        // Initial zoom value
    private Vector3 startPos;       // Initial camera position

    void Start()
    {
        cam = GetComponent<Camera>();        // Get camera on this object
        startZoom = cam.orthographicSize;    // Store initial zoom
        startPos = transform.position;       // Store initial position
    }

    void LateUpdate()
    {
        if (player == null) return; // Stop if player is missing

        if (zooming)
        {
            zoomTimer += Time.deltaTime;
            float t = zoomTimer / zoomDuration;

            // Move camera toward player smoothly
            Vector3 targetPos = new Vector3(player.position.x, player.position.y, startPos.z);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            // Smooth zoom transition
            cam.orthographicSize = Mathf.Lerp(startZoom, targetZoom, t);

            // End zoom when time finishes
            if (zoomTimer >= zoomDuration)
                zooming = false;
        }
        else
        {
            // Follow player smoothly after zoom
            Vector3 followPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followPos, followSpeed * Time.deltaTime);
        }
    }
}

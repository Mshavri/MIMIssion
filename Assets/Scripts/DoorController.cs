using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static bool IsKeyCollected = false;

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
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            if (IsKeyCollected)
            {
                Destroy(gameObject);
            }
        }
    }
}

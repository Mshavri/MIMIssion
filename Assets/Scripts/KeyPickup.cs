using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoorController.IsKeyCollected = true;
            Destroy(gameObject);
        }
    }
}

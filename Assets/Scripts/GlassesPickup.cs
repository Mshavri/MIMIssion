using UnityEngine;

public class GlassesPickup : MonoBehaviour
{
    public GameObject MotherNPC;
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            Collect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void Collect()
    {
        if (MotherNPC != null)
        {
            MotherNPC.SetActive(true);
        }
        Destroy(gameObject);
    }
}
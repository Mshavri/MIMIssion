using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool collected = false;
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            Collect();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void Collect()
    {
        if (!collected)
        {
            collected = true;
            FindObjectOfType<NpcInteraction>().CollectItem();
            gameObject.SetActive(false);
        }
    }
}
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            FindObjectOfType<NpcInteraction>().CollectItem();
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class GlassesPickup : MonoBehaviour
{
    public GameObject MotherNPC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MotherNPC != null)
            {
                MotherNPC.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}

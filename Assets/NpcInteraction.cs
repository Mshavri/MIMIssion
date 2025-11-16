using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject exclamationMark;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (exclamationMark != null)
            {
                exclamationMark.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (exclamationMark != null)
            {
                exclamationMark.SetActive(false);
            }
        }
    }
}
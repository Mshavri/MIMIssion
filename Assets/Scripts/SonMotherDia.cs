using UnityEngine;

public class SonMotherDia : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject clearContent;

    private bool playerNearby = false;

    void Start()
    {
        clearContent.SetActive(true);
        dialogueBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueBox.SetActive(false);
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueBox.SetActive(!dialogueBox.activeSelf);
        }
    }
}

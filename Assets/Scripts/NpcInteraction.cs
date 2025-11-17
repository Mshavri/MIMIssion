using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject scrambledText;
    public GameObject clearText;
    
    private bool playerNearby = false;
    private bool hasItem = false;

    void Start()
    {
        scrambledText.SetActive(true);
        clearText.SetActive(false);
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
            
            if (hasItem)
            {
                scrambledText.SetActive(false);
                clearText.SetActive(true);
            }
            else
            {
                scrambledText.SetActive(true);
                clearText.SetActive(false);
            }
        }
    }

    public void CollectItem()
    {
        hasItem = true;
    }
}

using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject dialogueBox;
    public GameObject scrambledText;
    public GameObject clearText;
    public DadPuzzle dadPuzzle;

    private bool playerInRange;

    void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }

        // Enable scrambled text by default if it exists
        if (scrambledText != null)
        {
            scrambledText.SetActive(true);
        }

        // Hide clear text at start
        if (clearText != null)
        {
            clearText.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);

                // If no puzzle is assigned, show default text
                if (dadPuzzle == null)
                {
                    if (scrambledText != null) scrambledText.SetActive(true);
                    if (clearText != null) clearText.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (dialogueBox != null)
            {
                dialogueBox.SetActive(false);
            }
        }
    }
}

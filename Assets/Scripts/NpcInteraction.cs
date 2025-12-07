using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject scrambledText;
    public GameObject clearText;

    public DadPuzzle dadPuzzle;  // مرجع للسكربت الجديد

    private bool playerNearby = false;
    private bool hasItem = false;

    void Start()
    {
        scrambledText.SetActive(true);
        clearText.SetActive(false);

        if (dadPuzzle != null)
        {
            dadPuzzle.answerInput.gameObject.SetActive(false);
            dadPuzzle.submitButton.SetActive(false);
        }
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

                if (dialogueBox.activeSelf && dadPuzzle != null)
                {
                    dadPuzzle.ShowInput();
                }
            }
            else
            {
                scrambledText.SetActive(true);
                clearText.SetActive(false);

                if (dadPuzzle != null)
                {
                    dadPuzzle.answerInput.gameObject.SetActive(false);
                    dadPuzzle.submitButton.SetActive(false);
                }
            }
        }
    }

    public void CollectItem()
    {
        hasItem = true;
    }
}

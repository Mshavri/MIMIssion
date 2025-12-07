using UnityEngine;
using TMPro;

public class DadPuzzle : MonoBehaviour
{
    public TMP_InputField answerInput;
    public GameObject submitButton;
    public string correctAnswer = "secret";

    private bool puzzleSolved = false;

    void Start()
    {
        if (answerInput != null)
            answerInput.gameObject.SetActive(false);

        if (submitButton != null)
            submitButton.SetActive(false);
    }

    public void ShowInput()
    {
        if (puzzleSolved)
            return;

        answerInput.gameObject.SetActive(true);
        submitButton.SetActive(true);

        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    public void CheckAnswer()
    {
        if (puzzleSolved)
            return;

        string playerAnswer = answerInput.text.Trim().ToLower();
        string correct = correctAnswer.Trim().ToLower();

        if (playerAnswer == correct)
        {
            puzzleSolved = true;

            if (TraitManager.Instance != null)
            {
                TraitManager.Instance.AddTrait();
            }

            answerInput.gameObject.SetActive(false);
            submitButton.SetActive(false);
        }
        else
        {
            answerInput.text = "";
            answerInput.ActivateInputField();
        }
    }
}

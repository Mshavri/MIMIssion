using UnityEngine;
using TMPro;

public class NpcPuzzle : MonoBehaviour
{
    public TMP_InputField answerInput;
    public GameObject submitButton;
    public string correctAnswer = "4";

    private bool puzzleSolved = false;

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

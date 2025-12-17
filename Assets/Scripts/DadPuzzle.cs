using UnityEngine;
using TMPro;

public class DadPuzzle : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject scrambledText;
    public GameObject clearText;
    public TMP_InputField answerInput;
    public GameObject submitButton;

    [Header("Settings")]
    public string correctAnswer = "10";
    public bool hasHeadphones = false;
    
    // متغير جديد لتذكر حالة الحل
    private bool isSolved = false;

    void OnEnable()
    {
        UpdateUIState();
    }

    public void ShowInput()
    {
        PlayerGotHeadphones();
    }

    public void PlayerGotHeadphones()
    {
        hasHeadphones = true;
        if (gameObject.activeInHierarchy)
        {
            UpdateUIState();
        }
    }

    void UpdateUIState()
    {
        // إذا كان اللغز محلولاً، نخفي خانات الإجابة
        if (isSolved)
        {
            if (scrambledText != null) scrambledText.SetActive(false);
            if (clearText != null) clearText.SetActive(true);
            
            if (answerInput != null) answerInput.gameObject.SetActive(false);
            if (submitButton != null) submitButton.SetActive(false);
            
            return; 
        }

        // إذا لم يكن محلولاً ومعه سماعة
        if (hasHeadphones)
        {
            if (scrambledText != null) scrambledText.SetActive(false);
            if (clearText != null) clearText.SetActive(true);
            
            if (answerInput != null) answerInput.gameObject.SetActive(true);
            if (submitButton != null) submitButton.SetActive(true);
        }
        // إذا لم يكن معه سماعة
        else
        {
            if (scrambledText != null) scrambledText.SetActive(true);
            if (clearText != null) clearText.SetActive(false);
            
            if (answerInput != null) answerInput.gameObject.SetActive(false);
            if (submitButton != null) submitButton.SetActive(false);
        }
    }

    public void CheckAnswer()
    {
        if (answerInput.text.Trim() == correctAnswer)
        {
            // نتأكد أنه لم يتم الحل سابقاً قبل إعطاء الجائزة
            if (!isSolved)
            {
                if (TraitManager.Instance != null)
                {
                    TraitManager.Instance.AddTrait();
                }
                isSolved = true; // نحدد أن اللغز تم حله
            }

            gameObject.SetActive(false);
        }
        else
        {
            answerInput.text = "";
        }
    }
}
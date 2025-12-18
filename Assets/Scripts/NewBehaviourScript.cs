using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Loads the First scene
    public void RestartGame()
    {
        SceneManager.LoadScene("First");
    }
}

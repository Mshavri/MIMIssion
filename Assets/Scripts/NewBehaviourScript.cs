using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // هذه الدالة ستقوم بنقلك لمشهد First مباشرة
    public void RestartGame()
    {
        SceneManager.LoadScene("First");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    public void Close()
    {
        Application.Quit();
    }

    public void NavigateToHome()
    {
        SceneManager.LoadScene(0);
    }
}

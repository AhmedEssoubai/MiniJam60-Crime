using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void Quit()
    {
        Application.Quit(10);
    }
}

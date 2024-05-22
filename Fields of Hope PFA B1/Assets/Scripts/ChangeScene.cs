using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChanged(string NameOfScene)
    {
        SceneManager.LoadScene(NameOfScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

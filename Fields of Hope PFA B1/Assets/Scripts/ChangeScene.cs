using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void SceneChanged(string name)
    {
        StartCoroutine(Anim(name));
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator Anim(string NameOfScene)
    {
        if (animator == null)
        {
            SceneManager.LoadScene(NameOfScene);
        }
        else
        {
            animator.SetFloat("POPILOPO", 1);
            yield return new WaitForSecondsRealtime(2f);
            SceneManager.LoadScene(NameOfScene);
            animator.SetFloat("POPILOPO", -1);
        }
    }
}

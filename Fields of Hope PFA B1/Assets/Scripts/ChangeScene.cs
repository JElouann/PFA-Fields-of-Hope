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
        Debug.Log(animator.GetFloat("POPILOPO"));
        animator.SetFloat("POPILOPO", 1);
        Debug.Log(animator.GetFloat("POPILOPO"));
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(NameOfScene);
        animator.SetFloat("LOL", 0);
    }
}

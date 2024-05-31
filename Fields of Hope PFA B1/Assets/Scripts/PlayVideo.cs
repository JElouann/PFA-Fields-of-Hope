using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField]
    GameObject Menu;

    [SerializeField]
    GameObject ImageAnimation;

    [SerializeField]
    GameObject Crossfade;

    [SerializeField]
    private VideoPlayer player;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    public void OnPlayVideo()
    {
        if (player)
        {
            StartCoroutine(Attendre1());
            StartCoroutine(Attendre2());
        }
    }
    private IEnumerator Attendre1()
    {
        animator.SetFloat("LOL", 1);
        yield return new WaitForSecondsRealtime(1f);
        Menu.SetActive(false);
        yield return new WaitForSecondsRealtime(0.25f);
        player.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        ImageAnimation.SetActive(true);
    }

    private IEnumerator Attendre2()
    {
        yield return new WaitForSecondsRealtime(12f);
        Crossfade.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Théo");
    }
}

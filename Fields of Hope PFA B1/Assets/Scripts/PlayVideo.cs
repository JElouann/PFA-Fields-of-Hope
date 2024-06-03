using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;

    [SerializeField]
    GameObject Menu;

    [SerializeField]
    GameObject ImageAnimation;

    [SerializeField]
    GameObject Crossfade;

    [SerializeField]
    private VideoPlayer videoplayer;

    [SerializeField]
    private Animator animator;


    private bool isplaying = false;

    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
    }

    public void OnPlayVideo()
    {
        if (videoplayer)
        {
            isplaying = true;
            Panel.SetActive(true);
            StartCoroutine(StartVideo());           
        }
    }

    public void PauseVideo()
    {
        if (isplaying == true)
        {
            isplaying= false;
            videoplayer.Pause();
        }
        else if (isplaying == false)
        {
            isplaying = true;
            videoplayer.Play();
        }
    }

    public void Skip()
    {
        if (videoplayer)
        {
            videoplayer.Stop();
        }
    }

    private IEnumerator StartVideo()
    {
        videoplayer.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        ImageAnimation.SetActive(true);
    }

    private IEnumerator Attendre2()
    {
        animator.SetFloat("LOL", 1);
        yield return new WaitForSecondsRealtime(1f);
        Menu.SetActive(false);
        yield return new WaitForSecondsRealtime(12f);
        Crossfade.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Théo");
    }
}

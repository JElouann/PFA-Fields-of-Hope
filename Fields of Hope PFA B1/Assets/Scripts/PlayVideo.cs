using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public void OnPlayVideo()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();

        if (player)
        {
            player.Play();
            StartCoroutine(Attendre());
        }
    }

    private IEnumerator Attendre()
    {
        yield return new WaitForSecondsRealtime(11f);
        SceneManager.LoadScene("ElouannTest");
    }
}

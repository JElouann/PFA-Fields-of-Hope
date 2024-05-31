using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFx : MonoBehaviour
{
    [SerializeField]
    private SoudFxManager soudFxManager;
    public void OnClick(AudioClip clip)
    {
        soudFxManager.PlaySoundFXClip(clip, transform, 1f);
    }
}

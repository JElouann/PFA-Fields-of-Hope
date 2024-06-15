using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONSTARTPLAYMUSIC : MonoBehaviour
{
    [SerializeField]
    PlayMusic popilopofaitdugrosson;

    private void Start()
    {
        popilopofaitdugrosson.PlayNextMusic();
    }
}

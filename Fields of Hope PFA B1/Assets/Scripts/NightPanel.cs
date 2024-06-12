using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class NightPanel : MonoBehaviour
{
    private Vector3 _basePos;
    public static bool IsNight;

    private void Awake()
    {
        _basePos = transform.position;
    }

    void Start()
    {
        print(_basePos);
        this.GetComponent<Image>().DOFade(0, 0);
    }

    public void Move(float height)
    {
        this.GetComponent<Image>().DOFade(1, 0.75f);
        this.transform.DOLocalMoveY(height, 0.6f);
    }
}

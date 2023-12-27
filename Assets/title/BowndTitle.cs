using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BowndTitle : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        transform.DOLocalMoveY(1.3f, 1.5f).SetEase(Ease.OutBounce);
        transform.DOLocalMoveX(0.0f, 0.5f);
    }

}


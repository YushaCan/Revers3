using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Vector3 finalPos;
    [SerializeField]
    private Ease ease;
    private Vector3 originalPos, currentPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        currentPos = finalPos;
        Move(currentPos);
    }

    // Update is called once per frame
    void Move(Vector3 pos)
    {
        transform.DOMove(pos, 2f).SetEase(ease).OnComplete(() => Move(currentPos)).SetDelay(0.5f);
        currentPos = currentPos == finalPos ? originalPos : finalPos;
    }
}

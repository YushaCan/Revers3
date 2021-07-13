using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] private Vector3 finalRot;
    [SerializeField] Ease ease;
    private Vector3 originalRot, currentRot;
    // Start is called before the first frame update
    void Start()
    {
        originalRot = transform.rotation.eulerAngles;
        currentRot = finalRot;
        Rotate(currentRot);
    }

    // Update is called once per frame
    void Rotate(Vector3 angle)
    {
        transform.DORotate(angle, 1f).SetEase(ease).OnComplete(() => Rotate(currentRot));
        currentRot = currentRot == finalRot ? originalRot : finalRot;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

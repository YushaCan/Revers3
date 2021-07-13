using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LastPage : MonoBehaviour
{
    public CanvasGroup YUSA;
    public CanvasGroup spaceText;
    // Start is called before the first frame update
    void Start()
    {
        DOTweenModuleUI.DOFade(YUSA, 1, 3);
        DOTweenModuleUI.DOFade(spaceText, 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }
}

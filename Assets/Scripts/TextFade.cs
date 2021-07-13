using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TextFade : MonoBehaviour
{
    public CanvasGroup Text;
    public CanvasGroup Image;
    public LevelLoader lvlLoader;
    // Start is called before the first frame update
    void Start()
    {
        DOTweenModuleUI.DOFade(Text, 1, 3);
        DOTweenModuleUI.DOFade(Image, 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lvlLoader.LoadNextLevel();
        }
    }
}

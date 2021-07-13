using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime = 0;
    public float startingTime = 45;
    public int currentTimeInt;
    [SerializeField] private TextMeshProUGUI countDownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTimeInt = (int) currentTime;
        countDownText.text = currentTimeInt.ToString(); 
        if(currentTime <= 0)
        {
            currentTime = 45;
        }
    }
}

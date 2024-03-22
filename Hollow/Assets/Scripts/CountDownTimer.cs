using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float timeValue = 40;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeValue / 60);
            int seconds = Mathf.FloorToInt(timeValue % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeValue = 0;
            int minutes = Mathf.FloorToInt(timeValue / 60);
            int seconds = Mathf.FloorToInt(timeValue % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    float lastDamageIncreaseTime = 0;
    public static int damageIncrease = 0;

    // void Awake()
    // {
    //     lastDamageIncreaseTime = 0;
    // }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (elapsedTime - lastDamageIncreaseTime >= 30)
        {
            damageIncrease += 1;
            lastDamageIncreaseTime = elapsedTime;
        }
        // Debug.Log("Damage: " + damageIncrease);
    }
}

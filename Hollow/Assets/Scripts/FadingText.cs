using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadingText : MonoBehaviour
{
    public TMP_Text levelUpMessage;
    private float fadeTime;
    private bool fadingIn;

    void Start()
    {
        levelUpMessage.text = "Level Up!";
        levelUpMessage.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fadingIn = false;
    }

    void Update()
    {
        // Debug.Log("isFadingIn: " + fadingIn);
        if(fadingIn)
        {
            FadeIn();
        }
        else if(levelUpMessage.color.a != 0)
        {
            levelUpMessage.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    public void IsFadingIn(bool fadingIn)
    {
        this.fadingIn = fadingIn;
    }

    public void FadeIn()
    {
        levelUpMessage.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        // When the text is fully fade in and it is out of the fade time, stop fading in
        if(levelUpMessage.color.a == 1 && fadeTime > 1.5f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }
}
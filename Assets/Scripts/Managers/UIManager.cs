﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    [SerializeField]
    private Image fader;
    protected override void Awake()
    {
        base.Awake();
        if (fader != null)
        {
            fader.gameObject.SetActive(false);
        }
    }
    public virtual void FaderOn(bool state,float duration)
    {
        if (fader != null)
        {
            fader.gameObject.SetActive(true);
            if (state == true)
            {
                StartCoroutine(FadeInOut.FadeImage(fader, duration, new Color(0, 0, 0, 1)));
            }
            else
                StartCoroutine(FadeInOut.FadeImage(fader, duration, new Color(0, 0, 0, 0)));
        }
    }
}

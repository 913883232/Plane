using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    public Image red;
    public Image blue;
    public Color a;
    public Color b;
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(FadeInOut.FadeImage(red, 10F, a));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(FadeInOut.FadeImage(blue, 10F, b));
        }
        
    }
}

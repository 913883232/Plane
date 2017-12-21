using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif
//暂停界面
public class PauseManager : MonoBehaviour {
    [SerializeField]
    private AudioMixerSnapshot paused, unpaused;
    [SerializeField]
    private CanvasGroup pauseGroup;
    bool isPause = true;

	void Start () {
        Pause();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}
    public void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01F);
        }
        else
        {
            unpaused.TransitionTo(.01F);
        }
    }

    public void Pause()
    {
        isPause = !isPause;
        Time.timeScale = isPause ? 0:1;
        pauseGroup.alpha = isPause ? 1 : 0;
        pauseGroup.interactable = isPause ? true : false;
        pauseGroup.blocksRaycasts = isPause ? true : false;
        Lowpass();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit;
#endif
    }
}

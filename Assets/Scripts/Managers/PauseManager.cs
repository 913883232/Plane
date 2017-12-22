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
    [SerializeField]
    private CanvasGroup settingGroup;
    bool isPause = false;

    Stack<CanvasGroup> canvasGroupStack = new Stack<CanvasGroup>();
    List<CanvasGroup> canvasGroupList = new List<CanvasGroup>();
	void Start () {
        canvasGroupList.Add(pauseGroup);
        canvasGroupList.Add(settingGroup);
        DisplayMenu();
	}
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
	}
    private void Lowpass()
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
    public void Esc()
    {
        if (!isPause  && canvasGroupStack.Count == 0)
        {
            isPause = !isPause;
            canvasGroupStack.Push(pauseGroup);
        }
        else 
        {
            if (canvasGroupStack.Count > 0)
                canvasGroupStack.Pop();
        }
        if (canvasGroupStack.Count == 0)
        {
            Pause();
        }
        DisplayMenu();
    }
    public void Setting()
    {
        canvasGroupStack.Push(settingGroup);
        DisplayMenu();
    }
    public void Pause()
    {
        isPause = !isPause;
        if (canvasGroupStack.Count > 0)
        {
            canvasGroupStack.Pop();
        }
        DisplayMenu();
    }

    //界面展示
    private void DisplayMenu()
    {
        foreach (var item in canvasGroupList)
        {
            item.alpha = 0;
            item.interactable = false;
            item.blocksRaycasts = false;
        }
        if (canvasGroupStack.Count > 0)
        {
            CanvasGroup cg = canvasGroupStack.Peek();
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
        Time.timeScale = isPause ? 0 : 1;
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

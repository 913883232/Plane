using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour {
    [SerializeField]
    private CanvasGroup victoryGroup;
    private LevelDirector director;
    void Start () {
        director = LevelDirector.Instance;
        director.VictoryAction += DisplayText;
        victoryGroup.alpha = 0;
	}
	public void DisplayText()
    {
        victoryGroup.alpha = 1;
        Time.timeScale = 0;
    }
}

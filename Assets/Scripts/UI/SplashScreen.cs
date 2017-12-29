using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {
    [SerializeField]
    private string loadSceneName;
	void Start () {
        UIManager.Instance.FaderOn(false, 2f);//alpha:1->0
        StartCoroutine(LoadFirstScene());
	}
	private IEnumerator LoadFirstScene()
    {
        yield return new WaitForSeconds(3F);//展示当前场景
        UIManager.Instance.FaderOn(true,1f);//alpha:0->1
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(loadSceneName);
    }
}

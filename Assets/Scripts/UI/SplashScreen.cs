using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {
    [SerializeField]
    private string loadSceneName;
	void Start () {
        UIManager.Instance.FaderOn(false, 1f);
        StartCoroutine(LoadFirstScene());
	}
	private IEnumerator LoadFirstScene()
    {
        yield return new WaitForSeconds(3F);
        UIManager.Instance.FaderOn(true,1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(loadSceneName);

    }
	void Update () {
		
	}
}

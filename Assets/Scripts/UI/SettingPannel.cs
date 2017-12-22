using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPannel : MonoBehaviour {
    [SerializeField]
    private Slider onMusicSlider;
    [SerializeField]
    private Slider onEffectSlider;
    void Start()
    {
        onMusicSlider.value = AudioManager.Instance.MusicVolume;
        onEffectSlider.value = AudioManager.Instance.EffectVolume;
    }

    public void OnMusicSlider(float value)
    {
        AudioManager.Instance.MusicVolume = value;
    }
    public void OnEffectSlider(float value)
    {
        AudioManager.Instance.EffectVolume = value;
    }
	
}

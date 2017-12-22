using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager> {
    [SerializeField]
    private GameSetting gameSetting;
    [SerializeField]
    private AudioMixer mixer;

    private float musicVolume;
    private float effectVolume;

	protected override void Awake () {
        base.Awake();
        musicVolume = gameSetting.musicVolume;
        effectVolume = gameSetting.effectVolume;
        mixer.SetFloat("music", musicVolume);
        mixer.SetFloat("effect", effectVolume);
    }
    public float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            gameSetting.musicVolume = value;
            musicVolume = value;
            mixer.SetFloat("music", value);
        }
    }
    public float EffectVolume
    {
        get { return effectVolume; }
        set
        {
            gameSetting.effectVolume = value;
            effectVolume = value;
            mixer.SetFloat("effect", value);
        }
    }
}

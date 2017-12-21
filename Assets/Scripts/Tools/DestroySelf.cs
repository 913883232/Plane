using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
    private Animator anim;
    private AudioSource audioSource;
    private float DestroyTime;
	void Awake () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if(anim)
        {
            DestroyTime = anim.GetCurrentAnimatorClipInfo(0).Length;
        }
        if(audioSource)
        {
            DestroyTime = audioSource.clip.length > DestroyTime ? audioSource.clip.length : DestroyTime;
        }
        Destroy(this.gameObject, DestroyTime);
	}
}

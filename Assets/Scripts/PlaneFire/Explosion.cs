using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Explosion : MonoBehaviour {
    private AudioMixer mix;
    private AudioSource exp;
    private Animator anim;
    private Animation mat;
	void Awake () {
        mix = GetComponent<AudioMixer>();
        exp = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        mat = GetComponent<Animation>();
	}
	
	void Update () {
		
	}
}

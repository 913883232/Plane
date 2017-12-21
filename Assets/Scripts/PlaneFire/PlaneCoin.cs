using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCoin : MonoBehaviour {
    private AudioSource audios;
    private Renderer rend;
    private Collider2D coll;
	void Awake () {
        audios = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider2D>();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MainPlane>())
        {
            coll.enabled = false;
            audios.Play();
            rend.enabled = false;
            LevelDirector.Instance.Score += 10;
            Destroy(gameObject,audios.clip.length);
        }
    }
}

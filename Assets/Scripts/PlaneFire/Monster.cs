using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    private AudioSource audios;
    private Renderer rend;
    private Collider2D coll;
    private Transform trans;
    [SerializeField]
    private float speed;
    void Awake()
    {
        audios = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider2D>();
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        trans.Translate(speed * Vector3.down * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            coll.enabled = false;
            audios.Play();
            rend.enabled = false;
            Destroy(gameObject, audios.clip.length);
        }

    }
}

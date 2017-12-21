using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmove : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Renderer rend;
    private Material mat;
	void Start () {
        rend = GetComponent<Renderer>();
        mat = rend.material;
	}
	
	void Update () {
        mat.mainTextureOffset = new Vector2(0, Time.time * speed);
	}
}

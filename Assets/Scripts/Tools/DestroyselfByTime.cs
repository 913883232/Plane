using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyselfByTime : MonoBehaviour {
	
	void Start () {
        Invoke("Destroyself", 10F);
	}
	private void Destroyself()
    {
        Destroy(this.gameObject);
    }
}

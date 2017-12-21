using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //子弹
    #region
    [SerializeField]
    private float speed;
    private float y;
    private Transform bossBullet;
    private Collider2D coll;
    void Awake()
    {
        bossBullet = GetComponent<Transform>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        y = speed * Time.deltaTime;
        bossBullet.Translate(0, -y, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //子弹销毁
        if (other.tag == "Player" || other.tag == "Bullet")
        {
            coll.enabled = false;
            Destroy(gameObject);
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainPlane : MonoBehaviour, IHealthable
{
    [SerializeField]
    private GameObject explosionFX;//添加特效

    private Transform trans;
    public GameObject bullet;//添加子弹
    public float speed;
    private AudioSource BulletAudio;//子弹音效
    [SerializeField]
    private Collider2D coll;
    //玩家血量
    private int health = 100;
    public int Health
    {
        get { return health; }
        private set { health = value; }
    }

    private float MaxX;
    private float MinX;
    private float MaxY;
    private float MinY;
    private float direction;
    public delegate void OnDead();
    public event OnDead OnDeadEvent;

    void Awake()
    {
        trans = GetComponent<Transform>();
        BulletAudio = GetComponent<AudioSource>();
        //玩家出场
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        StartCoroutine(DelayColl());
    }
    void Start()
    {
        MaxX = ScreenXY.MaxX;
        MinX = ScreenXY.MinX;
        MaxY = ScreenXY.MaxY;
        MinY = ScreenXY.MinY;
    }

    void Update()
    {
        //发射子弹
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        ClampFrame();
        Move();
    }
    //限制飞机范围
    private Vector3 ClampFrame()
    {
        trans.position = new Vector3(Mathf.Clamp(trans.position.x, MinX, MaxX), Mathf.Clamp(trans.position.y, MinY, MaxY), trans.position.z);
        return trans.position;
    }
    //生成子弹
    private void Fire()
    {
        Instantiate(bullet, trans.position, Quaternion.identity);
        BulletAudio.Play();
    }
    //飞机移动
    private void Move()
    {
        trans.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
    }
    //撞到Boss摧毁
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(gameObject.tag))
        {
            Damage(100);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Destroy(other.gameObject);
        }
    }
    private IEnumerator DelayColl()
    {
        yield return new WaitForSeconds(2F);
        coll.enabled = true;
    }
    public void Damage(int val)
    {
        Health -= val;
        if (Health <= 0)
        {
            DestroySelf();
        }
    }
    public void DestroySelf()
    {
        Instantiate(explosionFX, trans.position, Quaternion.identity);
        if (OnDeadEvent != null)
        {
            OnDeadEvent();
        }
        Destroy(this.gameObject);
    }
}

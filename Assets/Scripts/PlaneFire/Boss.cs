﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour,IHealthable
{
    public GameObject bulletPrefab;
    [SerializeField]
    private float repeatRate;
    public float speed;
    private float Hp = 10;

    private float MaxX;
    private float MinX;
    private float MaxY;
    private float MinY;
    private Vector3 direction;
    //血量
    private int health = 100;
    public int Health
    {
        get{return health;}
        private set{health = value;}
    }

    void Awake()
    {
        InvokeRepeating("Fire", 0, repeatRate);
        MaxX = ScreenXY.MaxX;
        MinX = ScreenXY.MinX;
        MaxY = ScreenXY.MaxY;
        MinY = ScreenXY.MinY;
        direction = Vector3.left;
    }
    void Update()
    {
        if (transform.position.x > MaxX)
        {
            direction = Vector3.left;
        }
        else if (transform.position.x < MinX)
        {
            direction = Vector3.right;
        }
        Move();
    }
    private void Fire()
    {
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }
    public void Damage(int val)
    {
        Health -= val;
        if (Health <= 0)
        {
            LevelDirector.Instance.Score += 100;
            Destroy(gameObject);
        }
        print("Boss血量"+health);
    }
    //Boss移动
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        transform.Translate(Vector3.down * Time.deltaTime * speed/25);
    }
}
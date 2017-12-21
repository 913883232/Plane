using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    protected override void Move()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}

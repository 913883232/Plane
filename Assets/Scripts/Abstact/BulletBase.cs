using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//抽象类
public abstract class BulletBase : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1;//子弹速度
    [SerializeField]
    private int power = 1;//子弹威力
    private Transform trans;
    //[SerializeField]
    //private GameObject myTag;
	void Awake () {
        trans = GetComponent<Transform>();
	}
	
	void Update () {
        Move();
	}
    //抽象方法，子类实现
    protected abstract void Move(); 
    // 
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IHealthable>() != null && !collision.CompareTag(gameObject.tag))
        {
            collision.GetComponent<IHealthable>().Damage(power);
            Destroy(this.gameObject);
        }
        #region//碰撞标签设置二
        //if (collision.GetComponent<IHealthable>() != null && !collision.CompareTag(myTag))
        //{
        //    collision.GetComponent<IHealthable>().Damage(power);
        //    Destroy(this.gameObject);
        //}
        #endregion
    }
}

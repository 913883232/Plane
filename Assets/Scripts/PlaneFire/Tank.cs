using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public GameObject bulletPrefab;
    private MainPlane mainplane;
    [SerializeField]
    private Transform barrelInitPos;
    [SerializeField]
    private Transform barrel;
    private float fireTimer;
    public float rateTimer;
    public float rotateSpeed;
    public float speed;
    private float minX;
    private Vector3 fireDirection;
    
    private Vector3 direction = Vector3.left;
    void Update () {
        minX = ScreenXY.MinX-1;
        Move();
        if (LevelDirector.Instance.currentPlane == null) return;
        mainplane = LevelDirector.Instance.currentPlane;
        fireTimer += Time.deltaTime;
        if (fireTimer > rateTimer)
        {
            Fire();
            fireTimer = 0;
        }
        BarrelRotate();
	}
    private void Fire()
    {
        Instantiate(bulletPrefab, barrelInitPos.position, barrel.rotation);
        if (barrel.position.x < minX)
            Destroy(this.gameObject);
    }
    private void BarrelRotate()
    {
        fireDirection = mainplane.transform.position - transform.position;
        fireDirection.z = 0;
        fireDirection = fireDirection.normalized;//等同于Vector3.Normalize(fireDirection)
        barrel.rotation = Quaternion.RotateTowards(barrel.rotation, Quaternion.FromToRotation(Vector3.down, fireDirection), rotateSpeed * Time.deltaTime);
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}

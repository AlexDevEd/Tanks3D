using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private float _bulletSpeed = 50f;
    [SerializeField] private float _destroyBulletTime = 3f;

    void Start()
    {

    }

    void Update()
    {
        ToShot();
    }

    private void ToShot()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_bullet, _spawnBullet.position, _spawnBullet.rotation);
            var rigidBody = bullet.GetComponent<Rigidbody>();
            rigidBody.velocity = transform.TransformDirection(Vector3.forward * _bulletSpeed);
            Destroy(bullet, _destroyBulletTime);
        }
    }
}

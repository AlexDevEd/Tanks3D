using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject[] _bullets;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private float _bulletSpeed = 50f;
    [SerializeField] private float _destroyBulletTime = 3f;
    [SerializeField] private AudioSource _shotSound;

    private GameObject _newBullet;
   
    enum BulletState { Silver, Gold, Purple }
    private BulletState _bulletState;

    private void Awake()
    {
        _shotSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        _bulletState = BulletState.Silver;
    }

    void Update()
    {
        ChooseBullet();
        if (Input.GetMouseButtonDown(0))
        {
            SetBullet();
            ToShot(_newBullet);
            Destroy(_newBullet, _destroyBulletTime);
        }
    }

    private void ToShot(GameObject bullet)
    {
        var rigidBody = bullet.GetComponent<Rigidbody>();
        rigidBody.velocity = transform.TransformDirection(Vector3.forward * _bulletSpeed);
    }

    private void SetBullet()
    {
        if (_bulletState == BulletState.Silver)
        {
            _newBullet = Instantiate(_bullets[0], _spawnBullet.position, _spawnBullet.rotation);
        }
        if (_bulletState == BulletState.Gold)
        {
            _newBullet = Instantiate(_bullets[1], _spawnBullet.position, _spawnBullet.rotation);
        }
        if (_bulletState == BulletState.Purple)
        {
            _newBullet = Instantiate(_bullets[2], _spawnBullet.position, _spawnBullet.rotation);
        }
    }

    private void ChooseBullet()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            _bulletState = BulletState.Silver;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            _bulletState = BulletState.Gold;
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            _bulletState = BulletState.Purple;
        }
    }
}

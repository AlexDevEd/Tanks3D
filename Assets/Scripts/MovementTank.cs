using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTank : MonoBehaviour
{ 
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _turret;
    [SerializeField] private float _tranlationSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private float _rotateTurretSpeed = 10f;

    private float _translation;
    private float _horizontalRotate;


    void Start()
    {
       // Instantiate(_player, transform.position, Quaternion.identity);

    }

    void Update()
    {
        Move();
        Rotate();
        RotateTurret();
    }

    private void Move()
    {
        _translation = Input.GetAxis("Vertical") * _tranlationSpeed;
        _player.transform.Translate(0,0, _translation * Time.deltaTime);
    }
    private void Rotate()
    {
        _horizontalRotate = Input.GetAxis("Horizontal") * _rotationSpeed;
        _player.transform.Rotate(0, _horizontalRotate * Time.deltaTime, 0);
    }

    private void RotateTurret()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _turret.transform.Rotate(Vector3.up * Time.deltaTime * _rotateTurretSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _turret.transform.Rotate(Vector3.down * Time.deltaTime * _rotateTurretSpeed);
        }

    }
}

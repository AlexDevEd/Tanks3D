using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTank : MonoBehaviour
{ 
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _turret;
    [SerializeField] private float _translationSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private float _rotateTurretSpeed = 10f;
    [SerializeField] private AudioSource _audioSource;


    //private AudioSource _audioSource;
    private float _translation;
    private float _horizontalRotate;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
            Move();
            Rotate();
            PlayAudio();
            RotateTurret();
    }

    private void Move()
    {
        _translation = Input.GetAxis("Vertical") * _translationSpeed;
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

    private void PlayAudio()
    {
        if (Math.Abs(_translation - Input.GetAxis("Vertical")) < 0.1f && Math.Abs(_horizontalRotate - Input.GetAxis("Horizontal")) < 0.1f)
        {
           // _audioSource.Play();
        }
    }
}

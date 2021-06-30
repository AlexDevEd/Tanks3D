using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletDamage;
    [SerializeField] private float _bulletSpeed = 50f;

    private AudioSource _explosionAudio;
    private ParticleSystem _bulletParticle;

    private void OnEnable()
    {
        _bulletParticle = GetComponent<ParticleSystem>();
        _explosionAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb" && collision.gameObject.tag == "Wall" && collision.gameObject.tag == "Enemy")
        {
            Explode();
        }
    }
    void Explode()
    {
        _bulletParticle.Play();
        _explosionAudio.Play();
    }
   
}

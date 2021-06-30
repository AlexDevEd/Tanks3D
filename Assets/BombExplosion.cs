using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private AudioSource _explosionAudio;

    private ParticleSystem _particle;
    private float _destroyTime = 0.5f;
  
    private void OnEnable()
    {
         _particle = GetComponent<ParticleSystem>();
        _explosionAudio = GetComponent<AudioSource>();
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Explode();
        }
    }
    void Explode()
    {
        _particle.Play();
        _explosionAudio.Play();
        Destroy(gameObject, _destroyTime);
    }

}

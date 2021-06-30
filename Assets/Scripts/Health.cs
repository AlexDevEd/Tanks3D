using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _startHeathPlayer;
    [SerializeField] private Slider _healthProgress;
    [SerializeField] private GameObject _explosionPrefab;

    private AudioSource _audioSource;
    private ParticleSystem _explosionParticles;
    private float _currentHealth;
    private bool _dead;

    private void Awake()
    {
        _explosionParticles = Instantiate(_explosionPrefab).GetComponent<ParticleSystem>();
        _audioSource = _explosionParticles.GetComponent<AudioSource>();
        _explosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _currentHealth = _startHeathPlayer;
        _dead = false;
        SetHealthUI();
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        SetHealthUI();

        if (_currentHealth <= 0f && !_dead)
        {
            OnDeath();
        }
    }


    private void SetHealthUI()
    {
        _healthProgress.value = _currentHealth;
    }


    private void OnDeath()
    {
        _dead = true;
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);
        _explosionParticles.Play();
        _audioSource.Play();
        gameObject.SetActive(false);
    }
}

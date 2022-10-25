using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
        
    [SerializeField] private float _minSpeed = 12;
    [SerializeField] private float _maxSpeed = 16;
    [SerializeField] private float _maxTorque = 10;
    [SerializeField] private float _xRange = 4;
    [SerializeField] private float _ySpawnPosition = -6;
    [SerializeField] private int pointValue = 1;

    private GameManager _gameManager;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(GetRandomUpwardsForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque(), ForceMode.Impulse);
        transform.position = GetRandomSpawnPosition();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPosition);
    }

    private float GetRandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 GetRandomUpwardsForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private void OnMouseDown()
    {
        if (!_gameManager.isGameOver)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }
}


using System;
using Den.Scripts;
using UnityEngine;


public class SpiningBeast : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private AngleLimits angleLimits;
    
    private float _currentAngle;
    private float _angleVelocity;
    private float _direction;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentAngle = angleLimits.min;
        _angleVelocity = 0;
        _direction = 1;

        _rigidbody.rotation = Quaternion.Euler(0, 0, _currentAngle);
    }

    private void FixedUpdate()
    {
        
    }
}

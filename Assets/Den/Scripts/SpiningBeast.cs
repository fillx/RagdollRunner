
using System;
using UnityEngine;


public class SpiningBeast : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;
    
    private float _currentAngle;
    private float _angleVelocity;
    private float _direction;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentAngle = -amplitude;
        _angleVelocity = 0;
        _direction = 1;

        _rigidbody.rotation = Quaternion.Euler(0, 0, _currentAngle);
    }

    private void FixedUpdate()
    {
        if (Mathf.Sign(_currentAngle * _direction) > 0)
            _direction *= -1;
        
        _angleVelocity += _direction * speed * Time.fixedDeltaTime;

        _currentAngle += _angleVelocity * Time.fixedDeltaTime;
        _rigidbody.MoveRotation(Quaternion.Euler(0, 0, _currentAngle));
    }
}

using System;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Den.Scripts
{
    public class Spinner : MonoBehaviour
    {
        [SerializeField] private float minSpeed = 100;
        [SerializeField] private float maxSpeed = 150;
        
        private Transform _transform;
        private float _speed;
        private float _angle;

        private void Start()
        {
            _transform = transform;
            PickSpeed();
        }

        private void FixedUpdate()
        {
            if (_angle > 360) PickSpeed();
            _angle += Time.fixedDeltaTime * _speed;
            _transform.localRotation = Quaternion.Euler(0, _angle, 0);
        }

        private void PickSpeed()
        {
            _speed = Random.Range(minSpeed, maxSpeed);
            _angle = 0;
        }
        
        
    }
}

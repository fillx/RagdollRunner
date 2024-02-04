using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingThing : MonoBehaviour
{
   [SerializeField] private float initialForce;
   [SerializeField] private float bounceForce;
   

   private Rigidbody _rigidbody;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _rigidbody.AddForce(_rigidbody.transform.up * initialForce, ForceMode.Acceleration);
   }

   private void OnCollisionEnter(Collision other)
   {
      _rigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Acceleration);
   }
}

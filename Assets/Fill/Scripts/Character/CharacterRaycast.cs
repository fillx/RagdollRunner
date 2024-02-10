using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRaycast : MonoBehaviour
{
   [SerializeField] private Transform Transform;
   [SerializeField] private Vector3 Size;
   [SerializeField] private Vector3 Offset;
   public bool isContactWithClimbing;
   
   private readonly Collider[] _colliders = new Collider[8];

   private Vector3 _center;
   private Vector3 _halfSize;
   private void FixedUpdate()
   {
      _center = Transform.position + Offset;
      _halfSize =Size / 2;
      var orientation = Quaternion.identity;
      var count = Physics.OverlapBoxNonAlloc(_center, _halfSize, _colliders, orientation,1<<6);
      isContactWithClimbing = Physics.CheckBox(_center, _halfSize, orientation, 1 << 6);

      for (int i = 0; i < count; i++)
      {
         //Debug.Log($"Contact with {_colliders[i].name}");
      }
   }

   private void OnDrawGizmos()
   {
      if(Transform == null) return;
      Gizmos.color= Color.magenta;
      Gizmos.DrawCube(Transform.position + Offset,Size);
   }
}

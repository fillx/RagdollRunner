using System;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterConfig", fileName = "CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
   public Color CharacterColor;
   public CharacterMono Prefab;

   public float RunForce;
   public float ClimbingForce;
   public Jump Jump;
   public float KnockoutTime;
}

[Serializable]
public struct Jump
{
   public float Angle;
   public ForceMode ForceMode;
   public float JumpForce;
   public float minVelocityX;
}

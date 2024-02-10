using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBody : MonoBehaviour
{
   [SerializeField] private MeshRenderer[] MeshRenderers;
   public void SetColor(Color color)
   {
      foreach (var meshRenderer in MeshRenderers)
      {
         meshRenderer.material.color = color;
      }  
   }
}

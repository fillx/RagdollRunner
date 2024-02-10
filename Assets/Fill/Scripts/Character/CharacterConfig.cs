using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterConfig", fileName = "CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
   public Color CharacterColor;
   public Character Prefab;
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class LeaderboardPanel : MonoBehaviour
{
    [FormerlySerializedAs("uiElement2Prefab")] [FormerlySerializedAs("UiElementPrefab")] [SerializeField] private LeaderboardElement uiElementPrefab;
    public void ShowLeaderboard(List<CharacterMono> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            var character = characters[i];
            character.Score += GameConfig.Instance.RaceConfig.ScoreReward[i];
        }
        
        characters.Sort((a, b) => 
           b.Score.CompareTo(b.Score));
        
        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < characters.Count; i++)
        {
            var character = characters[i];
            var instance = Instantiate(uiElementPrefab,transform);
            instance.Initialize(i,character);
        }
    }
}

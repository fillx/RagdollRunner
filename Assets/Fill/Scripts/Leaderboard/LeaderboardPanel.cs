using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private LeaderboardElement UiElementPrefab;
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
            var instance = Instantiate(UiElementPrefab,transform);
            instance.Initialize(i,character);
        }
    }
}

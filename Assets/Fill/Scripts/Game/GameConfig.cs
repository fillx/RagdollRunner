using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig", fileName = "GameConfig")]
public class GameConfig : SingletonScriptableObject<GameConfig>
{
    public CharacterConfig [] Characters;
    public RaceConfig RaceConfig;
}

[Serializable]
public struct RaceConfig
{
    public float StartRaceTime;
    public float FinishRaceTime;
    public int NumberOfRun;
    public int[] ScoreReward;
}

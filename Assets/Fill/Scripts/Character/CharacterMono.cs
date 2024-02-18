using System.Collections.Generic;
using UnityEngine;

public class CharacterMono : MonoBehaviour
{
    [SerializeField] private CharacterBody CharacterBody;
    [SerializeField] private CharacterTriggerListener CharacterTriggerListener;

    public CharacterConfig Config { get; private set; }
    public Transform BodyTransform { get; private set; }

    public int Score
    {
        get { return PlayerPrefs.GetInt(Config.CharacterColor.ToString(), 0);}
        set { PlayerPrefs.SetInt(Config.CharacterColor.ToString(),value); }
    }
    public void Construct(CharacterConfig config)
    {
        Config = config;
        CharacterBody.SetColor(config.CharacterColor);
        CharacterTriggerListener.Construct(this);
        BodyTransform = CharacterBody.transform;
    }
}

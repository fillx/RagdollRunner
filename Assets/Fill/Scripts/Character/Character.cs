using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterBody CharacterBody;
    public CharacterConfig Config { get; private set; }
    public void Initialize(CharacterConfig config)
    {
        Config = config;
        CharacterBody.SetColor(config.CharacterColor);
    }
}

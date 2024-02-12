using UnityEngine;

public class CharacterMono : MonoBehaviour
{
    [SerializeField] private CharacterBody CharacterBody;
    [SerializeField] private CharacterTriggerListener CharacterTriggerListener;
    public CharacterConfig Config { get; private set; }
    public Transform BodyTransform { get; private set; }
    public void Construct(CharacterConfig config)
    {
        Config = config;
        CharacterBody.SetColor(config.CharacterColor);
        CharacterTriggerListener.Construct(this);
        BodyTransform = CharacterBody.transform;
    }
}

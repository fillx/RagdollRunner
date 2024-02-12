using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI textField;
    public CharacterMono CharacterMono { get; private set; }
    public void Initialize(CharacterMono characterMono)
    {
        CharacterMono = characterMono;
        icon.color = characterMono.Config.CharacterColor;
    }

    public void UpdateText(int index)
    {
        textField.SetText((index + 1).ToString());
        transform.SetSiblingIndex(index);
    }
}
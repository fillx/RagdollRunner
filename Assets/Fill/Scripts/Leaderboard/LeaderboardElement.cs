using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI placeTextField;
    [SerializeField] private TextMeshProUGUI ScoreTextField;
    
    public void Initialize(int place,CharacterMono characterMono)
    {
        //CharacterMono = characterMono;
        placeTextField.SetText((place+ 1).ToString());
        icon.color = characterMono.Config.CharacterColor;
        ScoreTextField.SetText(characterMono.Score.ToString());
    }
}
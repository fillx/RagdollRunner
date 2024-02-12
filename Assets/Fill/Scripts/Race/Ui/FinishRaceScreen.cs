using GameSDK.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

public class FinishRaceScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image winImage;
    private SignalBus _signalBus;
    private int finishedCounter;

    private void Awake()
    {
        _signalBus = ServiceContainer.Resolve<SignalBus>();
        _signalBus.Subscribe<RaceFinishedSignal>(OnRaceFinished, this);
        _signalBus.Subscribe<CharacterFinishedSignal>(OnCharacterFinished, this);
        panel.SetActive(false);
    }

    private void OnCharacterFinished(CharacterFinishedSignal signal)
    {
        if(finishedCounter > 0) return;
        winImage.color = signal.Character.Config.CharacterColor;
        finishedCounter++;
    }

    private void OnDestroy()
    {
        _signalBus.UnsubscribeFromAll(this);
    }

    private void OnRaceFinished(RaceFinishedSignal obj)
    {
        panel.SetActive(true);
    }
}

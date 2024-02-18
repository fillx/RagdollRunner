using _4_Scripts.Core;
using GameSDK.Scripts.Character;
using UnityEngine;

public class FinishRaceScreen : MonoBehaviour
{
    [SerializeField] private LeaderboardPanel leaderboardPanelpanel;
    [SerializeField] private GameObject panel;
    private SignalBus _signalBus;

    private void Awake()
    {
        _signalBus = ServiceContainer.Resolve<SignalBus>();
        _signalBus.Subscribe<RaceFinishedSignal>(OnRaceFinished, this);
      
        panel.SetActive(false);
    }

  

    private void OnDestroy()
    {
        _signalBus.UnsubscribeFromAll(this);
    }

    private void OnRaceFinished(RaceFinishedSignal signal)
    {
        Dbg.LogYellow("RACE COMPLETE");
        panel.SetActive(true);
        leaderboardPanelpanel.ShowLeaderboard(signal.FinishedCharacters);
    }
}

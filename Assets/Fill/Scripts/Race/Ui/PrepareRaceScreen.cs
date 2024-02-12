using System.Collections;
using TMPro;
using UnityEngine;

public class PrepareRaceScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI counterTextField;
  
    private SignalBus _signalBus;
    private void Awake()
    {
        _signalBus = ServiceContainer.Resolve<SignalBus>();
        _signalBus.Subscribe<RacePrepareSignal>(OnRacePrepare, this);
        panel.SetActive(false);
    }

    private void OnRacePrepare(RacePrepareSignal signal)
    {
        panel.SetActive(true);
        StartCoroutine(StartRaceTimer(signal.RemainingTime));
    }

    private IEnumerator StartRaceTimer(float countDownTimer)
    {
        while (countDownTimer > 0)
        {
            counterTextField.SetText(countDownTimer.ToString("0"));
            countDownTimer -= Time.deltaTime;
            yield return null;
        }
        panel.SetActive(false);
    }


    private void OnDestroy()
    {
        _signalBus.Unsubscribe<RacePrepareSignal>(this);
    }
}

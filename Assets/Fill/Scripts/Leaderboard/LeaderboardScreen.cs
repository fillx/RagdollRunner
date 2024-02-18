using System;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private LeaderboardElement UiElementPrefab;
    private SignalBus _signalBus;
    private List<LeaderboardElement> characters = new List<LeaderboardElement>();
    private float accumulatedTime;

    private void Awake()
    {
        _signalBus = ServiceContainer.Resolve<SignalBus>();
        //_signalBus.Subscribe<CharacterSpawnedSignal>(OnCharacterSpawned, this); 
        _signalBus.Subscribe<RaceStartedSignal>(OnRaceStarted, this);
        _signalBus.Subscribe<RaceFinishedSignal>(OnRaceFinished, this);
        panel.gameObject.SetActive(false);
    }

    private void OnRaceStarted(RaceStartedSignal signal)
    {
        panel.SetActive(true);
    }

    private void OnRaceFinished(RaceFinishedSignal signal)
    {
        panel.SetActive(false);
    }

    private void OnDestroy()
    {
        _signalBus.UnsubscribeFromAll(this);
    }

    // private void OnCharacterSpawned(CharacterSpawnedSignal signal)
    // {
    //     var instance = Instantiate(UiElementPrefab, panel.transform);
    //     instance.Initialize(signal.CharacterMono);
    //     characters.Add(instance);
    // }

    // private void FixedUpdate()
    // {
    //     accumulatedTime += Time.fixedDeltaTime;
    //     if(accumulatedTime < 0.5f) return;
    //     accumulatedTime = 0;
    //     
    //     characters.Sort((a, b) => 
    //         (int)b.CharacterMono.BodyTransform.position.x.CompareTo
    //             ((int)a.CharacterMono.BodyTransform.position.x));
    //     
    //     for (int i = 0; i < characters.Count; i++)
    //     {
    //         characters[i].UpdateText(i);
    //     }
    // }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class RaceStateMachine : MonoStateMachine<RaceStateMachine.RaceState>
{
   public Transform FinishLine;
   public SignalBus SignalBus;
   public RaceConfig RaceConfig => GameConfig.Instance.RaceConfig;
   public List<CharacterMono> RaceCharacters;
   
   public enum RaceState
   {
      PrepareRace,
      Race,
      FinishRace
   }

   private void Awake()
   {
      SignalBus = ServiceContainer.Resolve<SignalBus>();
      
      States.Add(RaceState.PrepareRace, new GamePrepareRaceState(RaceState.PrepareRace, this));
      States.Add(RaceState.Race, new GameRaceState(RaceState.Race, this));
      States.Add(RaceState.FinishRace ,new GameFinishRaceState(RaceState.FinishRace, this));

      CurrentState = States[RaceState.PrepareRace];

      RaceCharacters = new List<CharacterMono>();
      SignalBus.Subscribe<CharacterSpawnedSignal>(OnCharacterSpawnedSignal, this);
   }

   private void OnCharacterSpawnedSignal(CharacterSpawnedSignal signal)
   {
      RaceCharacters.Add(signal.CharacterMono);
   }
}
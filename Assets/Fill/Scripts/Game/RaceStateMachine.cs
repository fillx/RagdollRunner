using System;

public class RaceStateMachine : MonoStateMachine<RaceStateMachine.RaceState>
{
   public SignalBus SignalBus;
   public RaceConfig RaceConfig => GameConfig.Instance.RaceConfig;
   
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
   }
}
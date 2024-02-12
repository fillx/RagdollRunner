using _4_Scripts.Core;
using UnityEngine;

public class GamePrepareRaceState : MonoBaseState<RaceStateMachine.RaceState>
{
    private readonly SignalBus _signalBus;
    private readonly RaceConfig _raceConfig;

    private float accumulatedTime;

    public GamePrepareRaceState(RaceStateMachine.RaceState key, RaceStateMachine contexts) : base(key)
    {
        _signalBus = contexts.SignalBus;
        _raceConfig = contexts.RaceConfig;
    }

    public override void OnStart()
    {
        Dbg.LogYellow(nameof(GamePrepareRaceState));
        accumulatedTime = 0;
    }

    public override void OnEnter()
    {
        _signalBus.FireSignal(new RacePrepareSignal(_raceConfig.StartRaceTime));
    }

    public override RaceStateMachine.RaceState GetNextState()
    {
        accumulatedTime+=Time.deltaTime;
        if (accumulatedTime < _raceConfig.StartRaceTime)
            return RaceStateMachine.RaceState.PrepareRace;
           return RaceStateMachine.RaceState.Race;
    }
}
using _4_Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class GameFinishRaceState : MonoBaseState<RaceStateMachine.RaceState>
{
    private float accumulatedTime;
    private readonly RaceConfig _raceConfig;
    private readonly SignalBus _signalBus;

    public GameFinishRaceState(RaceStateMachine.RaceState key, RaceStateMachine context) : base(key)
    {
        _raceConfig = context.RaceConfig;
        _signalBus = context.SignalBus;
    }

    public override void OnEnter()
    {
        //Dbg.LogYellow(nameof(GameFinishRaceState));
        accumulatedTime = 0;
    }

    public override void OnUpdate()
    {
        accumulatedTime += Time.deltaTime;
    }

    public override RaceStateMachine.RaceState GetNextState()
    {
        if (accumulatedTime > _raceConfig.FinishRaceTime)
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        return RaceStateMachine.RaceState.FinishRace;
    }
}
using _4_Scripts.Core;

public class GameRaceState : MonoBaseState<RaceStateMachine.RaceState>
{
    private readonly SignalBus _signalBus;

    public GameRaceState(RaceStateMachine.RaceState key, RaceStateMachine context) : base(key)
    {
        _signalBus = context.SignalBus;
    }

    public override void OnEnter()
    {
        Dbg.LogYellow(nameof(GameRaceState));
        _signalBus.FireSignal(new RaceStartedSignal());
    }

    public override RaceStateMachine.RaceState GetNextState()
    {
        return RaceStateMachine.RaceState.Race;
    }
}
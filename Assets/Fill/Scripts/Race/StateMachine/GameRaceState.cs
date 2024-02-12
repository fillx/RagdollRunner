using _4_Scripts.Core;
using GameSDK.Scripts.Character;

public class GameRaceState : MonoBaseState<RaceStateMachine.RaceState>
{
    private readonly SignalBus _signalBus;
    private RaceStateMachine.RaceState currentState;

    public GameRaceState(RaceStateMachine.RaceState key, RaceStateMachine context) : base(key)
    {
        _signalBus = context.SignalBus;
    }

    public override void OnEnter()
    {
        _signalBus.Subscribe<CharacterFinishedSignal>(OnCharacterFinishedSignal, this);
        currentState = RaceStateMachine.RaceState.Race;
        _signalBus.FireSignal(new RaceStartedSignal());
        Dbg.LogYellow(nameof(GameRaceState));
    }
    public override void OnExit()
    {
        _signalBus.Unsubscribe<CharacterFinishedSignal>(this);
    }
    
    private void OnCharacterFinishedSignal(CharacterFinishedSignal signal)
    {
        Dbg.LogYellow($"Player with color: {signal.Character.Config.CharacterColor} Finished");
        currentState = RaceStateMachine.RaceState.FinishRace;
    }


    public override RaceStateMachine.RaceState GetNextState()
    {
        return currentState;
    }
}
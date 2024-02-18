using System.Collections.Generic;
using _4_Scripts.Core;
using GameSDK.Scripts.Character;

public class GameRaceState : MonoBaseState<RaceStateMachine.RaceState>
{
    private readonly RaceStateMachine _context;
    private readonly SignalBus _signalBus;
    private RaceStateMachine.RaceState currentState;
    private List<CharacterMono> finishedCharacters;

    public GameRaceState(RaceStateMachine.RaceState key, RaceStateMachine context) : base(key)
    {
        finishedCharacters = new List<CharacterMono>(context.RaceCharacters.Count);
        _context = context;
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
        _signalBus.FireSignal(new RaceFinishedSignal(finishedCharacters));
        _signalBus.Unsubscribe<CharacterFinishedSignal>(this);
    }
    
    
    private void OnCharacterFinishedSignal(CharacterFinishedSignal signal)
    {
        finishedCharacters.Add(signal.Character);
        if (finishedCharacters.Count == _context.RaceCharacters.Count)
            currentState = RaceStateMachine.RaceState.FinishRace;
    }


    public override RaceStateMachine.RaceState GetNextState()
    {
        return currentState;
    }
}
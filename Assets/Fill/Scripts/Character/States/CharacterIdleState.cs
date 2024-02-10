using UnityEngine;

public class CharacterIdleState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly SignalBus _signalBus;

    private CharacterStateMachine.CharacterState nextState;
    public CharacterIdleState(CharacterStateMachine.CharacterState key, CharacterStateMachine contexts) : base(key)
    {
        _signalBus = contexts.SignalBus;
    }

    public override void OnEnter()
    {
        nextState = StateKey;
        _signalBus.Subscribe<RaceStartedSignal>(Test, this);
    }

    public override void OnExit()
    {
        _signalBus.Unsubscribe<RaceStartedSignal>(this);
    }
    
    private void Test(RaceStartedSignal signal)
    {
        nextState = CharacterStateMachine.CharacterState.Run;
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        return nextState;
    }
}
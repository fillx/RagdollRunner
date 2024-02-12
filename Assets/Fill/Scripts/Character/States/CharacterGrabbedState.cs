using _4_Scripts.Core;
using ActiveRagdoll;

public class CharacterGrabbedState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly CharacterTriggerListener _triggerListener;
    private readonly GrabScript _grab;

    public CharacterGrabbedState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _triggerListener = context.TriggerListener;
        _grab = context.GrabScript;
    }

    public override void OnEnter()
    {
        _triggerListener.isUnhook = false;
        Dbg.LogYellow("Grabbed");
    }

    public override void OnExit()
    {
        _grab.dropObject();
        _grab.isHolding = false;
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        if (_triggerListener.isUnhook) return CharacterStateMachine.CharacterState.Falling;
        return CharacterStateMachine.CharacterState.Grabbed;
    }
}
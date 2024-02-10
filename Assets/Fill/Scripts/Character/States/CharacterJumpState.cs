using UnityEngine;

public class CharacterJumpState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly Rigidbody _rigidbody;
    private readonly Transform _transform;

    public CharacterJumpState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _rigidbody = context.Rigidbody;
        _transform = context.transform;
    }

    public override void OnEnter()
    {
        Debug.Log("JumpState");
        _rigidbody.AddForce(_transform.up * 100, ForceMode.Impulse);
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        return CharacterStateMachine.CharacterState.Run;
    }
}
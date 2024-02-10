using UnityEngine;

public class CharacterRunState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly Rigidbody _rigidbody;
    private readonly Transform _transform;
    private readonly Animator _animator;
    private readonly int Moving = Animator.StringToHash("moving");
    private readonly CharacterRaycast _raycast;

    private bool isJump;
    private readonly CharacterTriggerListener _triggerListener;

    public CharacterRunState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _rigidbody = context.Rigidbody;
        _transform = context.transform;
        _animator = context.Animator;
        _raycast = context.CharacterRaycast;
        _triggerListener = context.TriggerListener;
    }

    public override void OnEnter()
    {
        Debug.Log("RunState");
        _animator.SetBool(Moving, true);
    }

    public override void OnUpdate()
    {
        _rigidbody.AddForce(_transform.forward * 1000 * Time.fixedDeltaTime);
    }

    public override void OnExit()
    {
        _triggerListener.isJump = false;
        _animator.SetBool(Moving, false);
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        if (_triggerListener.isJump) return CharacterStateMachine.CharacterState.Jump;
        if (_raycast.isContactWithClimbing) return CharacterStateMachine.CharacterState.Climbing;
        return CharacterStateMachine.CharacterState.Run;
    }
}
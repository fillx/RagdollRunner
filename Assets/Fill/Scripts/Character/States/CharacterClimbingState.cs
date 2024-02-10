using UnityEngine;

public class CharacterClimbingState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly CharacterStateMachine _context;
    private readonly Rigidbody _rigidbody;
    private readonly Transform _transform;
    private readonly CharacterRaycast _raycast;
    private readonly Animator _animator;
    
    private readonly int Moving = Animator.StringToHash("moving");

    public CharacterClimbingState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _context = context;
        _rigidbody = _context.Rigidbody;
        _transform = _context.transform;
        _raycast = _context.CharacterRaycast;
        _animator = context.Animator;
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        if (_raycast.isContactWithClimbing == false) return CharacterStateMachine.CharacterState.Run;
        return CharacterStateMachine.CharacterState.Climbing;
    }

    public override void OnEnter()
    {
        _animator.SetBool(Moving, true);
        Debug.Log("ClimbingState");
    }

    public override void OnUpdate()
    {
        _rigidbody.AddForce(_transform.up *6000 * Time.fixedDeltaTime);
        _rigidbody.AddForce(_transform.forward *1000 * Time.fixedDeltaTime);
    }
}
using _4_Scripts.Core;
using ActiveRagdoll;
using UnityEngine;

public class CharacterRunState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly Rigidbody _rigidbody;
    private readonly Transform _transform;
    private readonly Animator _animator;
    private readonly int Moving = Animator.StringToHash("moving");
    private readonly int HoldingLeft = Animator.StringToHash("HoldingLeft");
    private readonly CharacterRaycast _raycast;

    private bool isJump;
    private readonly CharacterTriggerListener _triggerListener;
    private readonly CharacterMono _character;
    private readonly PhysicsJointController _bodyJointController;
    private readonly GrabScript _grab;
    
    public CharacterRunState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _rigidbody = context.Rigidbody;
        _transform = context.transform;
        _animator = context.Animator;
        _raycast = context.CharacterRaycast;
        _triggerListener = context.TriggerListener;
        _character = context.CharacterMono;
        _bodyJointController = context.BodyJointController;
        _grab = context.GrabScript;
    }

    public override void OnEnter()
    {
        //Debug.Log("RunState");
        _animator.SetBool(Moving, true);
    }

    public override void OnUpdate()
    {
        var runForce = _character.Config.RunForce;
        //Debug.Log(_rigidbody.velocity.x);
        _rigidbody.AddForce(_transform.forward * runForce * Time.fixedDeltaTime);
        _animator.SetBool(HoldingLeft, _raycast.isTryCrabbing);
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
        if (_bodyJointController.isContact) return CharacterStateMachine.CharacterState.Falling;
        if (_grab.isHolding) return CharacterStateMachine.CharacterState.Grabbed;
        return CharacterStateMachine.CharacterState.Run;
    }
}
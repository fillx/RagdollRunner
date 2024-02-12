using _4_Scripts.Core;
using ActiveRagdoll;
using UnityEngine;

public class CharacterFallingState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly CharacterStateMachine _context;
    private readonly Animator _animator;
    private readonly int Falling = Animator.StringToHash("falling");
    private readonly PhysicsJointController _bodyJointController;
    private float accumulatedTime;
    private readonly CharacterMono _characterMono;

    public CharacterFallingState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _context = context;
        _animator = context.Animator;
        _bodyJointController = _context.BodyJointController;
        _characterMono = context.CharacterMono;
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > _characterMono.Config.KnockoutTime) return CharacterStateMachine.CharacterState.Run;
        return CharacterStateMachine.CharacterState.Falling;
    }

    public override void OnEnter()
    {
        //Dbg.LogMagenta("FallingState");
        _animator.SetBool(Falling,true);
        _bodyJointController.SetPositionStrength(0);
        _bodyJointController.GoLimp();
        _bodyJointController.isContact = false;
        accumulatedTime = 0;
    }

    public override void OnExit()
    {
        _animator.SetBool(Falling,false);
        _bodyJointController.ResetLimbStrength();
    }
}
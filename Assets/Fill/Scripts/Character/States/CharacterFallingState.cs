using ActiveRagdoll;
using UnityEngine;

public class CharacterFallingState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly CharacterStateMachine _context;
    private readonly Animator _animator;
    private readonly int Falling = Animator.StringToHash("falling");
    private readonly PhysicsJointController _jointContoller;

    public CharacterFallingState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _context = context;
        _animator = context.Animator;
        _jointContoller = _context.PhysicsJointController;
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.E)) return CharacterStateMachine.CharacterState.Idle;
        return CharacterStateMachine.CharacterState.Falling;
    }

    public override void OnEnter()
    {
        Debug.Log("FallingState");
        //_animator.SetBool(Falling,true);
        _jointContoller.SetPositionStrength(0);
        _jointContoller.GoLimp();
    }

    public override void OnExit()
    {
        //_animator.SetBool(Falling,false);
        _jointContoller.ResetLimbStrength();
    }
}
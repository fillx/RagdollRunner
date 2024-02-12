using UnityEngine;

public class CharacterJumpState : MonoBaseState<CharacterStateMachine.CharacterState>
{
    private readonly Rigidbody _rigidbody;
    private readonly Transform _transform;
    private readonly CharacterMono character;

    public CharacterJumpState(CharacterStateMachine.CharacterState key, CharacterStateMachine context) : base(key)
    {
        _rigidbody = context.Rigidbody;
        _transform = context.transform;
        character = context.CharacterMono;
    }

    public override void OnEnter()
    {
        //Debug.Log("JumpState");
        var jumpAngle = character.Config.Jump.Angle;
        var jumpForce = character.Config.Jump.JumpForce;
        var forceMode  = character.Config.Jump.ForceMode;
    
        float angleInRadians = jumpAngle * Mathf.Deg2Rad;
        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);
        var jumpDir = new Vector3(x,y,0);

        var vel = _rigidbody.velocity;
        var xv = _rigidbody.velocity.x;
        var minVelocity = character.Config.Jump.minVelocityX;
        _rigidbody.velocity = new Vector3(Mathf.Max(minVelocity, xv), vel.y, vel.x);
       // Debug.Log(_rigidbody.velocity.x);
        _rigidbody.AddForce(jumpDir * jumpForce, forceMode);
    }

    public override CharacterStateMachine.CharacterState GetNextState()
    {
        return CharacterStateMachine.CharacterState.Run;
    }
}
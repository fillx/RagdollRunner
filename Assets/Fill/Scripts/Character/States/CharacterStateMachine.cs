using System;
using ActiveRagdoll;
using UnityEngine;

public class CharacterStateMachine : MonoStateMachine<CharacterStateMachine.CharacterState>
{
    public Character Character;
    public Rigidbody Rigidbody;
    public Animator Animator;
    public PhysicsJointController PhysicsJointController;
    public CharacterRaycast CharacterRaycast;
    public CharacterTriggerListener TriggerListener;
    public SignalBus SignalBus;
    public enum CharacterState
    {
        Idle,
        Run,
        Falling,
        Jump,
        Climbing
    }

    private void Awake()
    {
        SignalBus = ServiceContainer.Resolve<SignalBus>();
        States.Add(CharacterState.Idle, new CharacterIdleState(CharacterState.Idle, this));
        States.Add(CharacterState.Run, new CharacterRunState(CharacterState.Run,this));
        States.Add(CharacterState.Falling, new CharacterFallingState(CharacterState.Falling, this));
        States.Add(CharacterState.Climbing, new CharacterClimbingState(CharacterState.Climbing, this));
        States.Add(CharacterState.Jump, new CharacterJumpState(CharacterState.Jump, this));
     
        
        CurrentState = States[CharacterState.Idle];
    }

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.J))
        //     PhysicsJointController.GoLimp();
    }
}
using ActiveRagdoll;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStateMachine : MonoStateMachine<CharacterStateMachine.CharacterState>
{
    public CharacterMono CharacterMono;
    public Rigidbody Rigidbody;
    public Animator Animator;
    [Header("Body")]
    public PhysicsJointController BodyJointController;
    public GrabScript GrabScript;
    public CharacterRaycast CharacterRaycast;
    public CharacterTriggerListener TriggerListener;
    public SignalBus SignalBus;
    public enum CharacterState
    {
        Idle,
        Run,
        Falling,
        Jump,
        Climbing,
        Grabbed
    }

    public void Awake()
    {
        SignalBus = ServiceContainer.Resolve<SignalBus>();
        States.Add(CharacterState.Idle, new CharacterIdleState(CharacterState.Idle, this));
        States.Add(CharacterState.Run, new CharacterRunState(CharacterState.Run,this));
        States.Add(CharacterState.Falling, new CharacterFallingState(CharacterState.Falling, this));
        States.Add(CharacterState.Climbing, new CharacterClimbingState(CharacterState.Climbing, this));
        States.Add(CharacterState.Jump, new CharacterJumpState(CharacterState.Jump, this));
        States.Add(CharacterState.Grabbed, new CharacterGrabbedState(CharacterState.Grabbed, this));
     
        
        CurrentState = States[CharacterState.Idle];
    }

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.J))
        //     PhysicsJointController.GoLimp();
    }
}
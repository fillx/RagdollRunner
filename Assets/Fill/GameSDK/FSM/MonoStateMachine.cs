using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoStateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, MonoBaseState<EState>> States = new Dictionary<EState, MonoBaseState<EState>>();

    protected MonoBaseState<EState> CurrentState;
    private bool IsTransitioningState = false;
    private void Start()
    {
        CurrentState.OnEnter();
    }

    void FixedUpdate()
    {
        EState nextStateKey = CurrentState.GetNextState();

        if (IsTransitioningState == false && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.OnUpdate();
        }
        else if(IsTransitioningState == false)
        {
            TransitionToState(nextStateKey);
        }
    }

    private void TransitionToState(EState stateKey)
    {
        IsTransitioningState = true;
        CurrentState.OnExit();
        CurrentState = States[stateKey];
        CurrentState.OnEnter();
        IsTransitioningState = false;
    }

    void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}
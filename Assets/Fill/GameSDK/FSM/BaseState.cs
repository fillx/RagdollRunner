using System;

public abstract class BaseState<Estate> : IState where Estate : Enum
{
    protected BaseState(Estate key)
    {
        StateKey = key;
    }

    public Estate StateKey { get; private set; }

    public abstract Estate GetNextState();

    public virtual void OnStart()
    {
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnUpdate()
    {
    }
    
    public virtual void OnExit()
    {
    }
}
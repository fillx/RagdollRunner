using System;
using UnityEngine;

public abstract class MonoBaseState<EState> : BaseState<EState>, IMonoTriggerEvent where EState : Enum
{
    protected MonoBaseState(EState key) : base(key)
    {
    }

    public virtual void OnFixedUpdate()
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
    }

    public virtual void OnTriggerStay(Collider other)
    {
    }

    public virtual void OnTriggerExit(Collider other)
    {
    }
}
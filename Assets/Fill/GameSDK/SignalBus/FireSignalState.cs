using System;

internal struct FiredSignalState
{
    public readonly Action OnComplete;
    public readonly int CurrentFireCount;

    public FiredSignalState(Action complete, int currentFireCount)
    {
        OnComplete = complete;
        CurrentFireCount = currentFireCount;
    }
}

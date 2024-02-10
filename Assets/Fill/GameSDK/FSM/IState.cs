using System.Collections;
using System.Collections.Generic;

public interface IState
{
    void OnStart();
    void OnEnter();
    void OnUpdate();
    void OnExit();
}
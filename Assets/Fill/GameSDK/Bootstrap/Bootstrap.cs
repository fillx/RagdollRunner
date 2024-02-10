using System.Collections;
using System.Collections.Generic;
using _4_Scripts.Core;
using _4_Scripts.Core.Task;
using UnityEngine;

public static class Bootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Dbg.LogYellow("Bootstrap Initialize");
        InitializationTasks.Run();
    }
    
    private static TaskQueue InitializationTasks => new List<Task>()
    {
        new InitializeSignalBusTask()
    };
}

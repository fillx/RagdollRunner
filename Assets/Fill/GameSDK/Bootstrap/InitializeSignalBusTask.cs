using _4_Scripts.Core.Task;
using GameSDK.Scripts.Race;

public class InitializeSignalBusTask : InstantTask
{
    protected override void InstantRun()
    {
        ServiceContainer.Register(new SignalBus());
        //ServiceContainer.Register(new RaceControlService());
    }
}

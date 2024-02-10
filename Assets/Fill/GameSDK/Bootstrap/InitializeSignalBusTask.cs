using _4_Scripts.Core.Task;

public class InitializeSignalBusTask : InstantTask
{
    protected override void InstantRun()
    {
        ServiceContainer.Register(new SignalBus());
    }
}

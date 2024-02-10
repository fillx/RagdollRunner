namespace _4_Scripts.Core.Task
{
    public abstract class InstantTask : Task
    {
        public sealed override void Run()
        {
            InstantRun();
            OnComplete.Invoke(this);
        }

        protected abstract void InstantRun();
    }
}
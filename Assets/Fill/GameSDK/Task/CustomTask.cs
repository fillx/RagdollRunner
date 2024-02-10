using System;

namespace _4_Scripts.Core.Task
{
    public class CustomTask : InstantTask
    {
        protected Action Action;

        public CustomTask(Action action)
        {
            this.Action = action;
        }

        protected override void InstantRun()
        {
            Action.Invoke();
        }
    }
}
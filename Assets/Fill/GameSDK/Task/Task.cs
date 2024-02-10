using System;

namespace _4_Scripts.Core.Task
{
    public abstract class Task
    {

        public Action<Task> OnComplete = t => { };
        public Action<Task, Exception> OnFailed = (t, e) => { };

        public abstract void Run();
    }
}
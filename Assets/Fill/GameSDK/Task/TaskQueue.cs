using System;
using System.Collections.Generic;

namespace _4_Scripts.Core.Task
{
    public class TaskQueue : Task
    {
        private readonly List<Task> _tasks = new List<Task>();

        public TaskQueue() { }

        public TaskQueue(List<Task> tasks)
        {
            _tasks = tasks;
        }


        public override void Run()
        {
            RunPendingTask();
        }

        private void RunPendingTask()
        {
            if (_tasks.Count == 0)
            {
                OnComplete?.Invoke(this);
                return;
            }

            var currentTask = _tasks[0];
            _tasks.RemoveAt(0);

            currentTask.OnComplete += OnCurrentTaskComplete;
            currentTask.OnFailed += OnTaskFailed;
            currentTask.Run();
        }

        private void OnCurrentTaskComplete(Task task)
        {
            RunPendingTask();
        }

        private void OnTaskFailed(Task task, Exception error)
        {
            task.OnComplete -= OnCurrentTaskComplete;
            task.OnFailed -= OnTaskFailed;
            OnFailed?.Invoke(task, error);
        }
        
        public static implicit operator TaskQueue(List<Task> t) => new TaskQueue(t);
    }
}
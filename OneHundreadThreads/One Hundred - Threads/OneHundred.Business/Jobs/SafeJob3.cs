using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace iQuest.OneHundred.Business.Jobs
{
    internal class SafeJob3 : IJob
    {
        private long value;

        public ushort ThreadCount { get; set; }

        public ulong IncrementCount { get; set; }

        public string Description { get; } = "Incrementing the value without any synchronization mechanism.";

        public JobResult Execute()
        {
            value = 0;
            TimeSpan elapsedTime = MeasureExecutionTime(RunAllThreads);

            return new JobResult
            {
                Value = value,
                ElapsedTime = elapsedTime
            };
        }

        private void RunAllThreads()
        {
            Mutex mutex = new Mutex();

            List<Thread> threads = Enumerable.Range(0, ThreadCount)
                .Select(x => StartNewThread(mutex))
                .ToList();

            foreach (Thread thread in threads)
                thread.Join();

            mutex.Close();
            mutex.Dispose();
        }

        private Thread StartNewThread(Mutex mutex)
        {
            Thread thread = new Thread(o =>
            {
                for (ulong i = 0; i < IncrementCount; i++)
                {
                    mutex.WaitOne();
                    value++;
                    mutex.ReleaseMutex();
                }
            });

            thread.Start();
            thread.Join();

            return thread;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
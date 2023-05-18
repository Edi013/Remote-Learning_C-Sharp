using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace iQuest.OneHundred.Business.Jobs
{
    internal class SafeJob2 : IJob
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
            Semaphore semaphore = new Semaphore(initialCount: 1, maximumCount: 1);

            List<Thread> threads = Enumerable.Range(0, ThreadCount)
                .Select(x => StartNewThread(semaphore))
                .ToList();

            foreach (Thread thread in threads)
                thread.Join();

            semaphore.Close();
            semaphore.Dispose();
        }

        private Thread StartNewThread(Semaphore semaphore)
        {
            Thread thread = new Thread(o =>
            {
                for (ulong i = 0; i < IncrementCount; i++)
                {
                   
                   
                        semaphore.WaitOne();
                        value++;
                        semaphore.Release();
                        
                      
                }
            });

            thread.Start();
            
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
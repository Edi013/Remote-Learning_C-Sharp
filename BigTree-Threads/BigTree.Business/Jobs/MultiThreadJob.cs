using System;
using System.Diagnostics;
using System.Threading;
using iQuest.BigTree.ThirdPartyLibrary;

namespace iQuest.BigTree.Business.Jobs
{
    internal class MultiThreadJob : IJob
    {
        public int LevelCount { get; set; }

        public string Description { get; } = "Multi thread generation";

       public JobResult Execute()
        {
            Node tree = null;

            TimeSpan elapsedTime = MeasureExecutionTime(() => { tree = GenerateNode(LevelCount - 1); });

            return new JobResult
            {
                Tree = tree,
                ElapsedTime = elapsedTime
            };
        }

        private static async Node GenerateNode(int descendentLevelCount)
        {
            Node node = new Node();

            Thread calculateValue = new Thread(_ => node.Values = ThirdPartyCalculator.Calculate()); //node.Values = ThirdPartyCalculator.Calculate());
            //calculateValue.Join();
            calculateValue.Start();

            if (descendentLevelCount > 0)
            {
                Thread calculateLeftNode = new Thread(_ => node.LeftNode = GenerateNode(descendentLevelCount - 1));
                calculateLeftNode.Start();  //node.LeftNode = GenerateNode(descendentLevelCount - 1);

                Thread calculateRightNode = new Thread(_ => node.RightNode = GenerateNode(descendentLevelCount - 1));
                calculateRightNode.Start(); // node.RightNode = GenerateNode(descendentLevelCount - 1);
            }

            return node;
        }
        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}

using System.Diagnostics;

namespace HBoxingAndUnboxing
{
    class BoxingAndUnboxing
    {
        public static int ReferenceType(long repeat)
        {
            int i = 0;

            for (int j = 1; j <= repeat; j++)
            {
                object obj = ++i;
                i = (int)obj;
            }

            return 0;
        }

        public static int ValueType(long repeat)
        {
            int i = 0;
            

            for (long j = 1; j <= repeat; j++)
            {
                int obj = ++i;
                i = obj;
            }

            return 0;
        }

        public static void MethodTester(Func<long, int> TestedMethod, long repeat)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            TestedMethod(repeat);
            stopwatch.Stop();
            DisplayDuration(stopwatch, repeat);
        }

        public static void DisplayDuration(Stopwatch stopwatch, long repeat)
        {
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format(
                "Miliseconds: {0}",
            ts.Milliseconds );

            Console.WriteLine(elapsedTime);
        }

        public static void DisplayNumberInGroupsOfDigits(long repeat)
        {
            int zeroKth = 0;
            long aux = repeat;
            while (aux != 1)
            {
                aux /= 10;
                zeroKth++;
            }

            Console.Write("Repeat: 1");

            if (zeroKth % 3 == 1)
            {
                Console.Write("0");
                zeroKth--;
            }

            if (zeroKth % 3 == 2)
            {
                Console.Write("00");
                zeroKth -= 2;
            }

            Console.Write(" ");
            for (int toZeroKth = 1; toZeroKth <= zeroKth; toZeroKth++)
            {
                Console.Write("0");
                if (toZeroKth % 3 == 0)
                    Console.Write(" ");
            }
            Console.WriteLine();

            
        }

        public static void InitiateTest(long repeat)
        {
            DisplayNumberInGroupsOfDigits(repeat);

            MethodTester(ValueType, repeat);
            MethodTester(ReferenceType, repeat);
        }



        public static void Main(string[] args)
        {
            long repeat;

            Console.WriteLine("The first miliseconds value will be from value type function\nThe second milisecods value will be from reference type function");
            Console.WriteLine("Both functions do the same thing, but the latter one is using boxing and unboxing.");

            repeat = 1000000;    // 1 000 000
            InitiateTest(repeat);

            repeat = 10000000;    // 10 000 000
            InitiateTest(repeat);

            repeat = 100000000;    // 100 000 000
            InitiateTest(repeat);

            repeat = 1000000000;    // 1 000 000 000
            InitiateTest(repeat);
        }
    }
}
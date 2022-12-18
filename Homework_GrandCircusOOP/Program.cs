namespace iQuest.GrandCircus
{
    class MainClass{
        static void Main()
        {
            Arena arena = new Arena();

            Circus circus = new Circus(arena);
            circus.Perform();

            Console.ReadKey();
        }
    }
}

using iQuest.VendingMachine.Business;

namespace iQuest.VendingMachine.Presentation
{
    public class MainDisplay : DisplayBase, IMainDisplay
    {
        public ICommand ChooseCommand(IEnumerable<ICommand> commands)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (ICommand command in commands)
                DisplayUseCase(command);

            while (true)
            {
                string rawValue = ReadCommandName();

                if (string.IsNullOrEmpty(rawValue))
                {
                    return commands.Where(x => x.Name.Equals("Shutdown")).First();
                }

                ICommand selectedCommand = commands.FirstOrDefault(x => x.Name == rawValue);
                if (selectedCommand == null)
                {
                    DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
                    continue;
                }
                
                return selectedCommand;
            }
        }

        private static void DisplayUseCase(ICommand command)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(command.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + command.Description);
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }

        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }

        public void DisplayLine(string message)
        {
            DisplayLine(message, ConsoleColor.White);
        }
    }

}

namespace iQuest.GrandCircus
{
    public class Arena
        {
            public Arena(){}

            public void PresentCircus(string CircusName)
            {
            Console.WriteLine("");
            Console.WriteLine($"I am glad to open --->>> '{CircusName}' Circus ! ! ! ");
            Console.WriteLine("");
            Console.WriteLine("");

            }
            public void AnnounceAnimal(string animalName, string animalSpecies)
            {
                Console.WriteLine($"Now! '{animalName}' from the species '{animalSpecies}' :");
            }
            public void DisplayAnimalPerformance(string animalSound)
            {
                Console.WriteLine("{0}", animalSound);
                Console.WriteLine("");
            }

    }

}
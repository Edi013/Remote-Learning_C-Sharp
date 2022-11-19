namespace iQuest.GrandCircus
{
  public class Circus{
        Arena arena;
        List<IAnimal> animals = new List<IAnimal>(); // List<IAnimal> sau List<AnimalBase> ???
        
        public Circus(Arena _arena){
            arena = _arena;
            animals.Add(new Elephant("Elefantasticul Dino", "Elefant 1592"));
            animals.Add(new Emu("You don't see me", "Emu 2018"));
            animals.Add(new Lion("Linos The King", "Lion 2022"));
            animals.Add(new Snake("Long Tail", "Snake 1205"));
        }
        public void Perform()
        {
          arena.PresentCircus("Generation Z");

          foreach (var animal in animals)
          {
            arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
            arena.DisplayAnimalPerformance(animal.MakeNoise());
          }  
        }
    }
}
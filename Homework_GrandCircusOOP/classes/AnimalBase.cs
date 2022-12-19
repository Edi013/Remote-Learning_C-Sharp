namespace iQuest.GrandCircus
{
    public abstract class AnimalBase : IAnimal
    {
        public string Name{ get; }
        public string SpeciesName{ get; }

        public AnimalBase(string name, string speciesName){
            this.Name = name;
            this.SpeciesName = speciesName;
        }

        public abstract string MakeNoise();
    }
}
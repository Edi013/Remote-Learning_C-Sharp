namespace iQuest.GrandCircus
{
    public class AnimalBase : IAnimal
    {
        public string Name{ get; }
        public string SpeciesName{ get; }

        public AnimalBase(string name, string speciesName){
            this.Name = name;
            this.SpeciesName = speciesName;
        }

        public virtual string MakeNoise()
            {
                return "idk what noise to use ";
            }
    }
}
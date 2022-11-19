namespace iQuest.GrandCircus
{
    public class AnimalBase : IAnimal{

        public string Name{ get; }
        public string SpeciesName{ get; }

        public AnimalBase(string Name, string SpeciesName){
            this.Name = Name;
            this.SpeciesName = SpeciesName;
        }

        public virtual string MakeNoise()
            {
                return "idk what noise to use ";
            }

    }
}
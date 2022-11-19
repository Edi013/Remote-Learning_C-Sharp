namespace iQuest.GrandCircus
{
    public class Lion : AnimalBase
    {
        public Lion(string Name, string SpeciesName): base(Name, SpeciesName)
        {
                
        }

        public override string MakeNoise()
        {
            return "rawwww";
        }
    }
}
namespace iQuest.GrandCircus
{
    public class Elephant : AnimalBase
    {
        public Elephant(string Name, string SpeciesName): base(Name, SpeciesName)
        {      
        }

        public override string MakeNoise()
        {
            return "e-e-el-ele-ELEPHANT";
        }
    }
}
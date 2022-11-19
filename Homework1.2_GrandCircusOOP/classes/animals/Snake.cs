namespace iQuest.GrandCircus
{
    public class Snake: AnimalBase
    {
        public Snake(string Name, string SpeciesName): base(Name, SpeciesName)
        {
                
        }

        public override string MakeNoise()
        {
            return "sssssssssssalut vrei sa fim prieteni?";
        }
    }
}
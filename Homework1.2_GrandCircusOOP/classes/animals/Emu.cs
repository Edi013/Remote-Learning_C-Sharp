namespace iQuest.GrandCircus
{
    public class Emu : AnimalBase
    {

        public Emu(string Name, string SpeciesName): base(Name, SpeciesName)
        {
        }

        public override string MakeNoise()
        {
            return " puf... *hiding his head in the ground*";
        }
    }
}
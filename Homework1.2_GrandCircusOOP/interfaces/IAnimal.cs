public interface IAnimal
{
  public string Name{ get; }
  public string SpeciesName { get; }
  public abstract string MakeNoise();
}
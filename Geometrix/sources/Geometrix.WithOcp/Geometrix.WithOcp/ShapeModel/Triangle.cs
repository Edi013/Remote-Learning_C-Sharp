namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double Base { get; set; }

        public double Height { get; set; }

        public double CalculateArea()
        {
            return (Base * Height )/2;
        }
    }
}
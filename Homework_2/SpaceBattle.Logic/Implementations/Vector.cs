namespace SpaceBattle.Logic.Implementations
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}
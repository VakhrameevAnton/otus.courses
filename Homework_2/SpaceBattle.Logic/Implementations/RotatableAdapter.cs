using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic.Implementations
{
    public class RotatableAdapter : IRotatable
    {
        public IUObject O;
        public RotatableAdapter(IUObject o)
        {
            O = o;
        }
        
        public int GetDirection()
        {
            return (int)O.GetProperty("Direction");
        }

        public int GetAngularVelocity()
        {
            return (int)O.GetProperty("AngularVelocity");
        }

        public void SetDirection(int newV)
        {
            O.SetProperty("Direction", newV);
        }

        public int GetDirectionsNumber()
        {
            return (int)O.GetProperty("DirectionsNumber");
        }
    }
}
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic.Implementations
{
    public class Rotate
    {
        private readonly IRotatable _r;
        public Rotate(IRotatable r)
        {
            _r = r;
        }

        public void Execute()
        {
            _r.SetDirection(_r.GetDirection() + _r.GetAngularVelocity() % _r.GetDirectionsNumber());
        }
    }
}
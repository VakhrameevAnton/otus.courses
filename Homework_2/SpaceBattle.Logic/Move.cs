using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic
{
    public class Move
    {
        private readonly IMovable _r;
        public Move(IMovable r)
        {
            _r = r;
        }

        public void Execute()
        {
            _r.SetPosition(_r.GetPosition() + _r.GetVelocity());
        }
    }
}
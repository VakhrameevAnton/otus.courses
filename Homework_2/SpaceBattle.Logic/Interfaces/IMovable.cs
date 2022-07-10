namespace SpaceBattle.Logic.Interfaces
{
    public interface IMovable
    {
        public Vector GetPosition();
        public void SetPosition(Vector newV);
        public Vector GetVelocity();
    }
}
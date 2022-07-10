namespace SpaceBattle.Logic.Interfaces
{
    public interface IRotatable
    {
        public int GetDirection();
        public int GetAngularVelocity();
        public void SetDirection(int newV);
        public int GetDirectionsNumber();
    }
}
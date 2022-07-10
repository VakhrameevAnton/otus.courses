namespace SpaceBattle.Logic.Interfaces
{
    public interface IUObject
    {
        public object GetProperty(string key);
        public void SetProperty(string key, object newValue);
    }
}
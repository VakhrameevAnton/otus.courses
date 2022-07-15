using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic.Implementations
{
    public class UObject : IUObject
    {
        private int Velocity { get; set; }
        private int Direction { get; set; }
        private int AngularVelocity { get; set; }
        private int DirectionsNumber { get; set; }

        public object GetProperty(string key)
        {
            var propInfo = GetType().GetProperty(key);
            return propInfo == null
                ? null
                : propInfo.GetValue(this, null);
        }

        public void SetProperty(string key, object newValue)
        {
            var propInfo = GetType().GetProperty(key);
            if (propInfo != null)
            {
                propInfo.SetValue(this, newValue, null);
            }
        }
    }
}
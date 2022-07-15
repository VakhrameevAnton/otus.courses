using SpaceBattle.Logic.CustomExceptions;
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic.Implementations
{
    public class ChangeVelocityCommand : IChangeVelocityCommand
    {
        private readonly IUObject _object;
        private readonly decimal _valueToChange;
        
        public ChangeVelocityCommand(IUObject uObject, decimal valueToChange)
        {
            _object = uObject;
            _valueToChange = valueToChange;
        }

        public void Execute()
        {
            var currentVelocity = (decimal)_object.GetProperty("velocity");
            if (currentVelocity == 0)
            {
                return;
            }
            
            var newValue = currentVelocity - _valueToChange;
            if (newValue < 0)
            {
                throw new CommandException();
            }
            
            _object.SetProperty("fuelAmount", newValue);
        }
    }
}
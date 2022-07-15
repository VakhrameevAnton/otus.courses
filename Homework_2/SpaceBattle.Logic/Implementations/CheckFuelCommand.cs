using SpaceBattle.Logic.CustomExceptions;
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic.Implementations
{
    public class CheckFuelCommand : ICheckFuelCommand
    {
        private readonly IUObject _object;
        private readonly decimal _valueToCheck;
        
        public CheckFuelCommand(IUObject uObject, decimal valueToCheck)
        {
            _object = uObject;
            _valueToCheck = valueToCheck;
        }
        
        public void Execute()
        {
            if ((decimal)_object.GetProperty("fuelAmount") < _valueToCheck)
            {
                throw new CommandException();
            }
        }
    }
}
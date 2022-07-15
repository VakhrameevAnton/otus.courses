using SpaceBattle.Logic.CustomExceptions;
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic.Implementations
{
    public class BurnFuelCommand : IBurnFuelCommand
    {
        private readonly IUObject _object;
        private readonly decimal _valueToBurn;
        
        public BurnFuelCommand(IUObject uObject, decimal valueToBurn)
        {
            _object = uObject;
            _valueToBurn = valueToBurn;
        }

        public void Execute()
        {
            var newValue = (decimal)_object.GetProperty("fuelAmount") - _valueToBurn;
            if (newValue < 0)
            {
                throw new CommandException();
            }
            
            _object.SetProperty("fuelAmount", newValue);
        }
    }
}
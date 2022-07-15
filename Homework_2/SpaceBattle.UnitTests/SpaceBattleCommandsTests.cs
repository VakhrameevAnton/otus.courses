using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SpaceBattle.Logic.CustomExceptions;
using SpaceBattle.Logic.Implementations;
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.UnitTests
{
    public class SpaceBattleCommandsTests
    {
        [Test]
        public void MacroCommand_Executed_ThrowsException()
        {
            var burnFuelMock = new Mock<IBurnFuelCommand>();
            burnFuelMock.Setup(bfc => bfc.Execute()).Throws(new CommandException());
            var checkFuelMock = new Mock<ICheckFuelCommand>();
            var moveMock = new Mock<IMoveCommand>();

            var macroCommand = new MacroCommand(
                new List<ICommand>
                {
                    checkFuelMock.Object, burnFuelMock.Object, moveMock.Object,
                });
            
            Assert.Throws<CommandException>(() => macroCommand.Execute());
        }
        
        [Test]
        public void MacroCommand_Executed_Ok()
        {
            var burnFuelMock = new Mock<IBurnFuelCommand>();
            var checkFuelMock = new Mock<ICheckFuelCommand>();
            var moveMock = new Mock<IMoveCommand>();

            var macroCommand = new MacroCommand(
                new List<ICommand>
                {
                    checkFuelMock.Object, burnFuelMock.Object, moveMock.Object,
                });
            
            Assert.DoesNotThrow(() => macroCommand.Execute());
        }

        [Test]
        public void CheckFuelCommand_Executed_ThrowsException()
        {
            var objectMock = new Mock<IUObject>();
            objectMock.Setup(o => o.GetProperty("fuelAmount")).Returns((decimal)5);

            var checkFuelCommand = new CheckFuelCommand(objectMock.Object, 6);
            
            Assert.Throws<CommandException>(() => checkFuelCommand.Execute());
        }
        
        [Test]
        public void CheckFuelCommand_Executed_Ok()
        {
            var objectMock = new Mock<IUObject>();
            objectMock.Setup(o => o.GetProperty("fuelAmount")).Returns((decimal)5);

            var checkFuelCommand = new CheckFuelCommand(objectMock.Object, 3);
            
            Assert.DoesNotThrow(() => checkFuelCommand.Execute());
        }
        
        [Test]
        [TestCase(10, 4)]
        [TestCase(10.5, 4.1)]
        public void BurnFuelCommand_Executed_Ok(decimal current, decimal value)
        {
            var objectMock = new Mock<IUObject>();
            objectMock.Setup(o => o.GetProperty("fuelAmount")).Returns(current);

            var burnFuelCommand = new BurnFuelCommand(objectMock.Object, value);
            
            Assert.DoesNotThrow(() => burnFuelCommand.Execute());
        }
        
        [Test]
        [TestCase(10, 12)]
        public void BurnFuelCommand_Executed_Throws(decimal current, decimal value)
        {
            var objectMock = new Mock<IUObject>();
            objectMock.Setup(o => o.GetProperty("fuelAmount")).Returns(current);

            var burnFuelCommand = new BurnFuelCommand(objectMock.Object, value);
            
            Assert.Throws<CommandException>(() => burnFuelCommand.Execute());
        }
        
        [Test]
        [TestCase(10, 12)]
        public void ChangeVelocityCommand_Executed_Throws(decimal current, decimal value)
        {
            var objectMock = new Mock<IUObject>();
            objectMock.Setup(o => o.GetProperty("velocity")).Returns(current);

            var changeVelocityCommand = new ChangeVelocityCommand(objectMock.Object, value);
            
            Assert.Throws<CommandException>(() => changeVelocityCommand.Execute());
        }
        
        [Test]
        [TestCase(10, 4)]
        [TestCase(0, 4.1)]
        public void ChangeVelocityCommand_Executed_Ok(decimal current, decimal value)
        {
            var objectMock = new Mock<IUObject>();
            objectMock.Setup(o => o.GetProperty("velocity")).Returns(current);

            var changeVelocityCommand = new ChangeVelocityCommand(objectMock.Object, value);
            
            Assert.DoesNotThrow(() => changeVelocityCommand.Execute());
        }
    }
}
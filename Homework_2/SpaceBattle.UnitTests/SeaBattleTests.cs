using System;
using Moq;
using NUnit.Framework;
using SpaceBattle.Logic;
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.UnitTests
{
    public class SeaBattleTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Move_Executed_SetVector_5_8()
        {
            var movableAdapter = new Mock<IMovable>();
            
            movableAdapter.Setup(x => x.GetPosition()).Returns(new Vector(12, 5));
            movableAdapter.Setup(x => x.GetVelocity()).Returns(new Vector(-7, 3));

            var move = new Move(movableAdapter.Object);
            move.Execute();
            
            movableAdapter.Verify(x => x.SetPosition(It.Is<Vector>(arg => arg.X == 5 && arg.Y == 8)));
        }
        
        [Test]
        public void GetPositionThrows_Executed_Exception()
        {
            var movableAdapter = new Mock<IMovable>();
            
            movableAdapter.Setup(x => x.GetPosition()).Throws(new Exception());
            movableAdapter.Setup(x => x.GetVelocity()).Returns(new Vector(-7, 3));

            var move = new Move(movableAdapter.Object);
            Assert.Throws<Exception>(() => move.Execute());
        }

        [Test]
        public void GetVelocityThrows_Executed_Exception()
        {
            var movableAdapter = new Mock<IMovable>();
            
            movableAdapter.Setup(x => x.GetPosition()).Returns(new Vector(12, 5));
            movableAdapter.Setup(x => x.GetVelocity()).Throws(new Exception());

            var move = new Move(movableAdapter.Object);
            
            Assert.Throws<Exception>(() => move.Execute());
        }
        
        [Test]
        public void SetPositionThrows_Executed_Exception()
        {
            var movableAdapter = new Mock<IMovable>();
            
            movableAdapter.Setup(x => x.GetPosition()).Returns(new Vector(12, 5));
            movableAdapter.Setup(x => x.GetVelocity()).Returns(new Vector(-7, 3));
            movableAdapter.Setup(x => x.SetPosition(It.IsAny<Vector>())).Throws(new Exception());

            var move = new Move(movableAdapter.Object);
            
            Assert.Throws<Exception>(() => move.Execute());
        }
    }
}
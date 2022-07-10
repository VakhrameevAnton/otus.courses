using System;
using NUnit.Framework;
using Otus.Library;

namespace Otus.UnitTests;

public class Tests
{
    private Calculator _calculator;
    
    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    [TestCase(1, 0, 1)]
    public void D_LessThan_0_EmptyRoots(double a, double b, double c)
    {
        // arrange
        
        // act
        var x = _calculator.Solve(a, b, c);
        
        // assert
        Assert.IsEmpty(x);
    }
    
    [Test]
    [TestCase(1, 0, -1)]
    [TestCase(2, 4.1, 2)]
    public void D_Equals_0_TwoRoot(double a, double b, double c)
    {
        // arrange
        
        // act
        var x = _calculator.Solve(a, b, c);
        
        // assert
        Assert.AreEqual(2, x.Length);
    }
    
    [Test]
    [TestCase(1, 2, 1)]
    public void D_GreaterThan_0_OneRoot(double a, double b, double c)
    {
        // arrange
        
        // act
        var x = _calculator.Solve(a, b, c);
        
        // assert
        Assert.AreEqual(1, x.Length);
    }
    
    [Test]
    [TestCase(0, 2, 1)]
    public void a_Equals_0_ThrowsException(double a, double b, double c)
    {
        // arrange
        
        // act
        
        // assert
        Assert.Throws<Exception>(() => _calculator.Solve(a, b, c));
    }
    
    [Test]
    [TestCase(double.NaN, 0, 1)]
    [TestCase(1, double.NaN, 1)]
    [TestCase(1, 0, double.NaN)]
    public void Coef_Is_Nan_ThrowsException(double a, double b, double c)
    {
        // arrange
        
        // act
        
        // assert
        Assert.Throws<Exception>(() => _calculator.Solve(a, b, c));
    }
}
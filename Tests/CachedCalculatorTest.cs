using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Substract()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        
        //Act
        var result = calc.Subtract(a, b);
        
        //Result
        Assert.That(result, Is.EqualTo(-1));
    }
    
    [Test]
    public void Multiply()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        
        //Act
        var result = calc.Multiply(a, b);
        
        //Assert 
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void Divide()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 4;
        var b = 2;
        
        //Act
        var result = calc.Divide(a, b);
        
        //Assert
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void FactorialNegativeArgumentException()
    {
        //Arrange
        var calc = new CachedCalculator();
        var n = -1;
        
        //Act, Assert
        Assert.Throws<ArgumentException>( () => calc.Factorial(n));
    }

    [Test]
    public void FactorialPositiveArgument()
    {
        //Arrange
        var calc = new CachedCalculator();
        var n = 5;
        
        //Act
        var result = calc.Factorial(n);
        
        //Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void FactorialArugmentIsZero()
    {
        //Arrange
        var calc = new CachedCalculator();
        var n = 0;
        
        //Act
        var result = calc.Factorial(n);
        
        //Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void IsPrimeLessThanTwo()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 1;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsPrimeTrue()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 7;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrimeFalse()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 8;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void Add_ShouldUseCache()
    {
        // Arrange
        var calculator = new CachedCalculator();
        string cacheKey = "2Add3";

        // Act
        int saveToCache = calculator.Add(2, 3);

        //Assert
        Assert.IsTrue(calculator._cache.ContainsKey(cacheKey));
    }

    [Test]
    public void Substract_ShouldUseCache()
    {
        // Arrange
        var calculator = new CachedCalculator();
        string cacheKey = "2Subtract3";
        
        // Act
        int saveToCache = calculator.Subtract(2, 3);
        
        // Assert
        Assert.IsTrue(calculator._cache.ContainsKey(cacheKey));
    }

    public void Multiply_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        string cacheKey = "2Multiply3";
        
        int saveToCache = calculator.Multiply(2, 3);
        
        Assert.IsTrue(calculator._cache.ContainsKey(cacheKey));
    }

    public void Divide_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        string cacheKey = "2Divide3";
        
        int saveToCache = calculator.Divide(2, 3);
        
        Assert.IsTrue(calculator._cache.ContainsKey(cacheKey));
    }

    [Test]
    public void Factorial_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        string cacheKey = "5Factorial";
        
        int saveToCache = calculator.Factorial(5);
        
        Assert.IsTrue(calculator._cache.ContainsKey(cacheKey));
    }

    [Test]
    public void IsPrime_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        string cacheKey = "5IsPrime";
        
        bool saveToCache = calculator.IsPrime(5);
        
        Assert.IsTrue(calculator._cache.ContainsKey(cacheKey));
    }
}
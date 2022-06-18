namespace Otus.Library;

public class Calculator
{
    public double[] Solve(double a, double b, double c)
    {
        if (a.Equals(0) | Double.IsInfinity(a) | Double.IsNaN(a))
        {
            throw new Exception();
        }

        if (Double.IsInfinity(b) | Double.IsNaN(b))
        {
            throw new Exception();
        }
        
        if (Double.IsInfinity(c) | Double.IsNaN(c))
        {
            throw new Exception();
        }

        var d = b * b - 4 * a * c;
        if (d < 0)
        {
            return Array.Empty<double>();
        }

        if (IsApproximatelyEqual(0, d, Double.Epsilon))
        {
            return new[] { -b / 2 * a };
        }
        
        var x1 = (-b + Math.Sqrt(d)) / 2 * a;
        var x2 = (-b - Math.Sqrt(d)) / 2 * a;

        return new[] { x1, x2 };
    }

    private bool IsApproximatelyEqual(double value1, double value2, double epsilon)
    {
        // If they are equal anyway, just return True.
        if (value1.Equals(value2))
        {
            return true;
        }

        // Handle NaN, Infinity.
        if (Double.IsInfinity(value1) | Double.IsNaN(value1))
        {
            return value1.Equals(value2);
        }

        if (Double.IsInfinity(value2) | Double.IsNaN(value2))
        {
            return value1.Equals(value2);
        }

        return Math.Abs(value1 - value2) <= epsilon;
    }
}
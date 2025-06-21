using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Financial Forecasting Tool ===");

        Console.Write("Enter current value (e.g., 10000): ");
        double currentValue = double.Parse(Console.ReadLine());

        Console.Write("Enter annual growth rate (e.g., 0.1 for 10%): ");
        double growthRate = double.Parse(Console.ReadLine());

        Console.Write("Enter number of years to forecast: ");
        int years = int.Parse(Console.ReadLine());

        double futureValue = Forecaster.PredictFutureValue(currentValue, growthRate, years);

        Console.WriteLine($"\nForecasted value after {years} years: {futureValue:F2}");

        Console.ReadLine();
    }
}

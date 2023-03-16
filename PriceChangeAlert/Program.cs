using System;

namespace PriceChangeAlert
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double significanceThreshold = double.Parse(Console.ReadLine());
            double previousPrice = double.Parse(Console.ReadLine());
            
            for (int i = 1; i < n; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());
                double differencePercentage = GetDifferencePercentage(previousPrice, currentPrice);
                
                bool isSignificant = Math.Abs(differencePercentage) > significanceThreshold;
                string message = GetMessage(currentPrice, previousPrice, differencePercentage, isSignificant);
                
                Console.WriteLine(message);
                
                previousPrice = currentPrice;
            }
        }

        static double GetDifferencePercentage(double previousPrice, double currentPrice)
        {
            return (currentPrice - previousPrice) / previousPrice * 100;
        }

        static string GetMessage(double currentPrice, double previousPrice, double differencePercentage, bool isSignificant)
        {
            if (differencePercentage == 0)
            {
                return string.Format($"NO CHANGE: {currentPrice}");
            }
            else if (!isSignificant)
            {
                return string.Format($"MINOR CHANGE: {previousPrice} to {currentPrice} ({differencePercentage:F2}%)");
            }
            else if (differencePercentage > 0)
            {
                return string.Format($"PRICE UP: {previousPrice} to {currentPrice} ({differencePercentage:F2}%)");
            }
            else
            {
                return string.Format($"PRICE DOWN: {previousPrice} to {currentPrice} ({differencePercentage:F2}%)");
            }
        }
    }
}
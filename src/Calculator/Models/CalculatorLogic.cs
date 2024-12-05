using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Models

{
    public class Calculator
    {
        public static double CalculateMean(IEnumerable<double> values)
        {
            if (!values.Any()) throw new ArgumentException("Values cannot be empty.");
            return values.Average();
        }
        
        public static double CalculateSampleStdDev(IEnumerable<double> values)
        {
            int n = values.Count();
            if (n < 2) throw new ArgumentException("At least two values are required.");
            double mean = CalculateMean(values);
            return Math.Sqrt(values.Sum(x => Math.Pow(x - mean, 2)) / (n - 1));
        }
        
        public static double CalculatePopulationStdDev(IEnumerable<double> values)
        {
            if (!values.Any()) throw new ArgumentException("Values cannot be empty.");
            double mean = CalculateMean(values);
            return Math.Sqrt(values.Sum(x => Math.Pow(x - mean, 2)) / values.Count());
        }
        
        public static double CalculateZScore(double value, double mean, double stdDev)
        {
            if (stdDev == 0) throw new ArgumentException("Standard deviation cannot be zero.");
            return (value - mean) / stdDev;
        }
        
        public static (double Slope, double Intercept) CalculateLinearRegression(IEnumerable<(double X, double Y)> dataPoints)
        {
            int n = dataPoints.Count();
            if (n < 2) throw new ArgumentException("At least two data points are required.");
            
            double meanX = CalculateMean(dataPoints.Select(p => p.X));
            double meanY = CalculateMean(dataPoints.Select(p => p.Y));
            double numerator = dataPoints.Sum(p => (p.X - meanX) * (p.Y - meanY));
            double denominator = dataPoints.Sum(p => Math.Pow(p.X - meanX, 2));

            if (denominator == 0) throw new InvalidOperationException("Cannot calculate slope; denominator is zero.");
            double slope = numerator / denominator;
            double intercept = meanY - slope * meanX;

            return (slope, intercept);
        }
        
        public static double PredictY(double x, double slope, double intercept) => slope * x + intercept;
    }
}
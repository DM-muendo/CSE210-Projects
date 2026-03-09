using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<double> previousAverages = new List<double>();

        while (true)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            List<double> numbers = new List<double>();
            double input;

            do
            {
                Console.Write("Enter number: ");
                input = Convert.ToDouble(Console.ReadLine());
                if (input != 0)
                {
                    numbers.Add(input);
                }
            } while (input != 0);

            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered.");
                continue;
            }

            // Core Requirements
            double sum = 0;
            double max = double.MinValue;
            double minPositive = double.MaxValue;

            foreach (double num in numbers)
            {
                sum += num;
                if (num > max)
                {
                    max = num;
                }
                if (num > 0 && num < minPositive)
                {
                    minPositive = num;
                }
            }

            double average = sum / numbers.Count;

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge: Smallest positive number
            if (minPositive != double.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {minPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers entered.");
            }

            // Stretch Challenge: Sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (double num in numbers)
            {
                Console.WriteLine(num);
            }

            // Comparison with previous averages
            if (previousAverages.Count > 0)
            {
                double previousAverage = previousAverages[previousAverages.Count - 1];
                if (average > previousAverage)
                {
                    Console.WriteLine($"Great job! The current average ({average}) is higher than the previous one ({previousAverage}).");
                }
                else if (average < previousAverage)
                {
                    Console.WriteLine($"The current average ({average}) is lower than the previous one ({previousAverage}).");
                }
                else
                {
                    Console.WriteLine($"The current average ({average}) is the same as the previous one ({previousAverage}).");
                }
            }

            previousAverages.Add(average);

            // Ask to play again
            Console.Write("Do you want to enter another list? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain != "yes")
            {
                break;
            }
        }
    }
}
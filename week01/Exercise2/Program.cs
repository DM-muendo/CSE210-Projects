using System;

class Program
{
    static void Main(string[] args)
    {
        int failCount = 0;

        while (true)
        {
            Console.Write("Enter your grade percentage: ");
            int percentage = int.Parse(Console.ReadLine());

            string letter = "";
            if (percentage >= 90)
            {
                letter = "A";
            }
            else if (percentage >= 80)
            {
                letter = "B";
            }
            else if (percentage >= 70)
            {
                letter = "C";
            }
            else if (percentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Determine sign
            int lastDigit = percentage % 10;
            string sign = "";
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }

            // Handle special cases
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }
            if (letter == "F")
            {
                sign = "";
            }

            Console.WriteLine($"Your grade is {letter}{sign}");

            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
                break;
            }
            else
            {
                failCount++;
                if (failCount == 3)
                {
                    Console.WriteLine("Keep trying! You'll get it next time.");
                    break;
                }
            }
        }
    }
}
using System;
using System.IO;

// To exceed core requirements, I added a simple logging feature that tracks the number of activities performed
// and saves it to a file called "activity_log.txt". Each time an activity is completed, it increments the count
// and writes it to the file. This provides a basic way to keep track of usage without complex statistics.

class Program
{
    static void Main(string[] args)
    {
        int activityCount = LoadActivityCount();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityCount++;
                    SaveActivityCount(activityCount);
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    activityCount++;
                    SaveActivityCount(activityCount);
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityCount++;
                    SaveActivityCount(activityCount);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static int LoadActivityCount()
    {
        if (File.Exists("activity_log.txt"))
        {
            string content = File.ReadAllText("activity_log.txt");
            if (int.TryParse(content, out int count))
            {
                return count;
            }
        }
        return 0;
    }

    static void SaveActivityCount(int count)
    {
        File.WriteAllText("activity_log.txt", count.ToString());
    }
}
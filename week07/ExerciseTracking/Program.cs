using System;

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        var activities = new Activity[]
        {
            new Running("03 Nov 2022", 30, 4.8),
            new Cycling("04 Nov 2022", 45, 15.0),
            new Swimming("05 Nov 2022", 40, 30)
        };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
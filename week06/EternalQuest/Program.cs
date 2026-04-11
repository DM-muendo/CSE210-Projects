using System;

class Program
{
    // Exceeding requirements: Added Leveling system, badges, and negative goals for bad habits.
    // See menu options and comments below for details.
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int level = 1;
        List<string> badges = new List<string>();
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine($"Score: {manager.GetScore()} | Level: {level} | Badges: {string.Join(", ", badges)}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    ListGoals(manager);
                    break;
                case "3":
                    RecordEvent(manager);
                    break;
                case "4":
                    Console.Write("Enter filename to save: ");
                    manager.SaveGoals(Console.ReadLine());
                    Console.WriteLine("Goals saved.");
                    break;
                case "5":
                    Console.Write("Enter filename to load: ");
                    manager.LoadGoals(Console.ReadLine());
                    Console.WriteLine("Goals loaded.");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            // Leveling system: Level up every 1000 points
            int newLevel = 1 + manager.GetScore() / 1000;
            if (newLevel > level)
            {
                level = newLevel;
                Console.WriteLine($"Congratulations! You reached Level {level}!");
                badges.Add($"Level {level}");
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (lose points for bad habits)");
        Console.Write("Choice: ");
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());
        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                // NegativeGoal: lose points when recorded (creative extension)
                manager.AddGoal(new NegativeGoal(name, desc, -Math.Abs(points)));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals(GoalManager manager)
    {
        var goals = manager.GetGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].GetName()} - {goals[i].GetDescription()}");
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        var goals = manager.GetGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }
        ListGoals(manager);
        Console.Write("Enter goal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= goals.Count)
        {
            manager.RecordEvent(num - 1);
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
    }
}
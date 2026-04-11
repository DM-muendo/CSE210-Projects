using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore() => _score;
    public List<Goal> GetGoals() => _goals;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count) return;
        Goal goal = _goals[goalIndex];
        int points = goal.GetPoints();
        if (goal is ChecklistGoal checklist)
        {
            int before = checklist.GetCurrentCount();
            checklist.RecordEvent();
            int after = checklist.GetCurrentCount();
            if (after > before)
            {
                _score += points;
                if (checklist.IsComplete() && before < checklist.GetTargetCount())
                {
                    _score += checklist.GetBonus();
                }
            }
        }
        else if (goal is NegativeGoal)
        {
            goal.RecordEvent();
            _score += points; // points is negative
        }
        else
        {
            bool wasComplete = goal.IsComplete();
            goal.RecordEvent();
            if (goal is SimpleGoal && !wasComplete && goal.IsComplete())
            {
                _score += points;
            }
            else if (goal is EternalGoal)
            {
                _score += points;
            }
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();
        if (!File.Exists(filename)) return;
        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            if (parts.Length != 2) continue;
            string type = parts[0];
            string[] data = parts[1].Split(",");
            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3])));
                    break;
            }
        }
    }
}
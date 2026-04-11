using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
            _currentCount++;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() => IsComplete() ? $"[X] Completed {_currentCount}/{_targetCount} times" : $"[ ] Completed {_currentCount}/{_targetCount} times";

    public int GetBonus() => _bonus;
    public int GetCurrentCount() => _currentCount;
    public int GetTargetCount() => _targetCount;

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_bonus},{_currentCount}";
    }
}
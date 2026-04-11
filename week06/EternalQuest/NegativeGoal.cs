using System;

// Creative extension: NegativeGoal deducts points for bad habits
public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override void RecordEvent()
    {
        _timesRecorded++;
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[!] Recorded {_timesRecorded} times (bad habit)";

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name},{_description},{_points},{_timesRecorded}";
    }
}
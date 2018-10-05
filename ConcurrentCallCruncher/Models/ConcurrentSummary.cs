using System;
using System.Collections.Generic;
using System.Linq;

public class ConcurrentSummary
{
    public string Program { get; set; }
    public string Office { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int TotalIntervals { get; set; }
    public List<Concurrent> Counts { get; set; }

    public ConcurrentSummary() {}

    public ConcurrentSummary(string Program, string Office, DateTime Start, DateTime End, IntervalSummary intervals)
    {
        this.Program = Program;
        this.Office = Office;
        this.Start = Start;
        this.End = End;

        Counts = new List<Concurrent>();

        TotalIntervals = intervals.Intervals.Count;
        var min = intervals.Intervals.Min(x => x.Calls);
        var max = intervals.Intervals.Max(x => x.Calls);

        for (int i = min; i <= max; i++)
        {
            Counts.Add(new Concurrent { Calls = i, Count = intervals.Intervals.Count(x => x.Calls == i) });
        }
    }
}

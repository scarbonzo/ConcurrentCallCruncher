using System.Collections.Generic;
using System.Linq;

class ConcurrentSummary
{
    public int TotalIntervals { get; set; }
    public List<Concurrent> Counts { get; set; }

    public ConcurrentSummary(IntervalSummary intervals)
    {
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

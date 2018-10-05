using System;
using System.Collections.Generic;
using System.Linq;

public class IntervalSummary
{
    public List<Interval> Intervals { get; set; }

    public IntervalSummary(List<Call> calls, double IntervalInSeconds)
    {
        Intervals = new List<Interval>();

        // Calculate the size of the Interval
        var delta = TimeSpan.FromSeconds(IntervalInSeconds).Ticks;

        // Calculate the start and end of the Intervals by checking the earliest start time and latest end time and rounding up to the passed IntervalInSeconds value
        var low = (calls.Min(x => x.Start).Ticks + delta - 1) / delta * delta;
        var high = (calls.Max(x => x.End).Ticks + delta - 1) / delta * delta;

        //Iterate from the rounded low Tick to the rounded high Tick and add an interval for it to the Intervals List
        for (long i = low; i <= high; i = i + delta)
        {
            var t = new DateTime(i);

            //Check day of week, only add Mon-Fri
            if (t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday)
            {
                if (t.Hour >= 8 && t.Hour <= 18)
                {
                    Intervals.Add(new Interval { Tick = i, Calls = 0 });
                }
            }
        }
    }

    public IntervalSummary(DateTime Start, DateTime End, double IntervalInSeconds)
    {
        Intervals = new List<Interval>();

        // Calculate the size of the Interval
        var delta = TimeSpan.FromSeconds(IntervalInSeconds).Ticks;

        // Calculate the start and end of the Intervals by checking the earliest start time and latest end time and rounding up to the passed IntervalInSeconds value
        var low = (Start.Ticks + delta - 1) / delta * delta;
        var high = (End.Ticks + delta - 1) / delta * delta;

        //Iterate from the rounded low Tick to the rounded high Tick and add an interval for it to the Intervals List
        for (long i = low; i <= high; i = i + delta)
        {
            var t = new DateTime(i);

            //Check day of week, only add Mon-Fri
            if (t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday)
            {
                if (t.Hour >= 8 && t.Hour <= 18)
                {
                    Intervals.Add(new Interval { Tick = i, Calls = 0 });
                }
            }
        }
    }
}

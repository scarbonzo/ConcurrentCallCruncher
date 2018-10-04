using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var calls = TestData();
        var intervals = new IntervalSummary(calls, 60);

        foreach(var i in intervals.Intervals)
        {
            foreach(var c in calls)
            {
                if (c.CheckTime(i.Tick))
                    i.Calls++;
            }
        }

        var summary = new ConcurrentSummary(intervals);

        Console.WriteLine("Total Intervals: " + summary.TotalIntervals.ToString());
        foreach (var c in summary.Counts)
        {
            Console.WriteLine(c.Calls + " Calls => " + c.Count + " intervals (" + ((decimal)c.Count / (decimal)summary.TotalIntervals).ToString() + "%)");
        }
        Console.ReadLine();
    }

    static List<Call> TestData()
    {
        var calls = new List<Call>();

        calls.Add(new Call { Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 9, 10, 0) });
        calls.Add(new Call { Start = new DateTime(2018, 1, 1, 9, 5, 0), End = new DateTime(2018, 1, 1, 9, 8, 0) });
        calls.Add(new Call { Start = new DateTime(2018, 1, 1, 9, 7, 0), End = new DateTime(2018, 1, 1, 9, 20, 0) });
        calls.Add(new Call { Start = new DateTime(2018, 1, 1, 9, 25, 0), End = new DateTime(2018, 1, 1, 9, 30, 0) });

        return calls;
    }
}

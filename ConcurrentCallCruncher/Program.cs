using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

class Program
{
    static void Main()
    {
        var folder = @"C:\VS\VoiceServicesAnalysis\VoiceServicesAnalysisUX\src\assets\json\";
        // var start = new DateTime(2017, 10, 1, 0, 0, 0);
        var start = new DateTime(2018, 9, 28, 0, 0, 0);
        var end = new DateTime(2018, 9, 28, 23, 59, 59);

        Console.WriteLine("Starting @ " + DateTime.Now.ToString());
        var alloffices = GenerateOffices();

        var programs = alloffices.GroupBy(x => x.Program);

        foreach (var p in programs)
        {
            var pr = new ProgramReport();

            Console.WriteLine("Starting program " + p.Key + " @ " + DateTime.Now.ToString());
            var offices = alloffices.Where(x => x.Program == p.Key);

            var summaries = new List<ConcurrentSummary>();

            foreach (var o in offices)
            {
                var or = new OfficeReport();
                
                Console.WriteLine("Starting office " + o.Name + " @ " + DateTime.Now.ToString());
                summaries.Add(GenerateSummary(o.Program, o.Name, start, end, GetIntervals(start, end, 60), GetCalls(o.Wildcards, start, end)));
                Console.WriteLine("Finished office " + o.Name + " @ " + DateTime.Now.ToString());
            }

            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(List<ConcurrentSummary>));
            ser.WriteObject(ms, summaries);
            var json = ms.ToArray();
            ms.Close();

            var filename = folder + p.Key.ToLower()
                .Replace(" ", "")
                .Replace(".", "")
                + ".json";

            var contents = Encoding.UTF8.GetString(json, 0, json.Length);

            if (!File.Exists(filename))
            {
                File.WriteAllLines(filename, new string[] { "{" });
                File.AppendAllLines(filename, new string[] { "\"program\": \"" + p.Key + "\"," });
                File.AppendAllLines(filename, new string[] { "\"start\": \"" + start.ToString() + "\"," });
                File.AppendAllLines(filename, new string[] { "\"end\": \"" + end.ToString() + "\"," });
                File.AppendAllLines(filename, new string[] { "\"summaries\": " });

                File.AppendAllLines(filename, new string[] { contents });

                File.AppendAllLines(filename, new string[] { "}" });
            }
            Console.WriteLine("Finished program " + p.Key + " @ " + DateTime.Now.ToString());
        }
        Console.WriteLine("Finished @ " + DateTime.Now.ToString());
    }

    static IntervalSummary GetIntervals(DateTime Start, DateTime End, int IntervalInSeconds)
    {
        return new IntervalSummary(Start, End, IntervalInSeconds);
    }

    static List<Call> GetCalls(string[] Wildcards, DateTime Start, DateTime End)
    {
        var calls = new List<Call>();
        var results = new List<TblCallsFull>();

        using (var db = new CallAnalyzerContext())
        {
            var query = db.TblCallsFull
                .Where(c => c.DateTimeDisconnect >= Start && c.DateTimeDisconnect <= End);

            foreach (var w in Wildcards)
            {
                results.AddRange(query.Where(x => x.OrigDeviceName.Contains(w) || x.DestDeviceName.Contains(w)).ToList());
            }
            foreach (var r in results)
            {
                calls.Add(new Call
                {
                    End = (DateTime)r.DateTimeDisconnect,
                    Start = ((DateTime)r.DateTimeDisconnect).AddMinutes(-Convert.ToDouble(r.Duration))
                });
            }
        }

        return calls;
    }

    static ConcurrentSummary GenerateSummary(string Program, string Office, DateTime Start, DateTime End, IntervalSummary Intervals, List<Call> Calls)
    {
        var j = 0m;
        foreach (var i in Intervals.Intervals)
        {
            j++;
            Console.Title = (j / Intervals.Intervals.Count * 100).ToString("#.##") + "%";
            foreach (var c in Calls)
            {
                if (c.CheckTime(i.Tick))
                    i.Calls++;
            }
        }

        return new ConcurrentSummary(Program, Office, Start, End, Intervals);
    }

    static List<Office> GenerateOffices()
    {
        var offices = new List<Office>();

        offices.Add(new Office { Program = "LSNJ", Name = "Edison", Wildcards = new string[] { "lsnj1-" } });
        offices.Add(new Office { Program = "LSNJ", Name = "Total", Wildcards = new string[] { "lsnj1-" } });

        offices.Add(new Office { Program = "ENLS", Name = "Newark", Wildcards = new string[] { "lsnj15-" } });
        offices.Add(new Office { Program = "ENLS", Name = "Total", Wildcards = new string[] { "lsnj15-" } });

        offices.Add(new Office { Program = "NNJLS", Name = "Paterson", Wildcards = new string[] { "lsnj8-" } });
        offices.Add(new Office { Program = "NNJLS", Name = "Jersey City", Wildcards = new string[] { "lsnj11-" } });
        offices.Add(new Office { Program = "NNJLS", Name = "Hackensack", Wildcards = new string[] { "lsnj19-" } });
        offices.Add(new Office { Program = "NNJLS", Name = "Total", Wildcards = new string[] { "lsnj8-", "lsnj11-", "lsnj19-" } });

        offices.Add(new Office { Program = "LSNWJ", Name = "Somervile", Wildcards = new string[] { "lsnj4-" } });
        offices.Add(new Office { Program = "LSNWJ", Name = "Newton", Wildcards = new string[] { "lsnj5-" } });
        offices.Add(new Office { Program = "LSNWJ", Name = "Belvidere", Wildcards = new string[] { "lsnj7-" } });
        offices.Add(new Office { Program = "LSNWJ", Name = "Morristown", Wildcards = new string[] { "lsnj9-" } });
        offices.Add(new Office { Program = "LSNWJ", Name = "Flemington", Wildcards = new string[] { "lsnj10-" } });
        offices.Add(new Office { Program = "LSNWJ", Name = "Total", Wildcards = new string[] { "lsnj4-", "lsnj5-", "lsnj7-", "lsnj9-", "lsnj10-" } });

        offices.Add(new Office { Program = "CJLS", Name = "New Brunswick", Wildcards = new string[] { "lsnj2-" } });
        offices.Add(new Office { Program = "CJLS", Name = "Perth Amboy", Wildcards = new string[] { "lsnj3-" } });
        offices.Add(new Office { Program = "CJLS", Name = "Trenton", Wildcards = new string[] { "lsnj6-" } });
        offices.Add(new Office { Program = "CJLS", Name = "Elizabeth", Wildcards = new string[] { "lsnj12-" } });
        offices.Add(new Office { Program = "CJLS", Name = "Total", Wildcards = new string[] { "lsnj2-", "lsnj3-", "lsnj6-", "lsnj12-" } });

        offices.Add(new Office { Program = "SJLS", Name = "Freehold", Wildcards = new string[] { "lsnj13-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Toms River", Wildcards = new string[] { "lsnj14-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Atlantic City", Wildcards = new string[] { "lsnj17-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Cape May", Wildcards = new string[] { "lsnj18-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Camden", Wildcards = new string[] { "lsnj20-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Vineland", Wildcards = new string[] { "lsnj21-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Mt. Holly", Wildcards = new string[] { "lsnj22-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Woodbury", Wildcards = new string[] { "lsnj23-" } });
        offices.Add(new Office { Program = "SJLS", Name = "Total", Wildcards = new string[] { "lsnj13-", "lsnj14-", "lsnj17-", "lsnj18-", "lsnj20-", "lsnj21-", "lsnj22-", "lsnj23-" } });

        return offices;
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

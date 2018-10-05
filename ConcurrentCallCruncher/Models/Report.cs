using System;
using System.Collections.Generic;
using System.Text;

public class ProgramReport
{
    public string Program { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Intervals { get; set; }
    public int MaxConcurrentCalls { get; set; }
    public List<OfficeReport> OfficeReports { get; set; }
}

public class OfficeReport
{
    public string Office { get; set; }
    public List<Concurrent> ConcurrentCalls { get; set; }
}
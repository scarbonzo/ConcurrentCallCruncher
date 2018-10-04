using System;

class Call
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    // Checks to see if the call exists during the given time (in Ticks)
    public bool CheckTime(long TimeInTicks)
    {
        return Start.Ticks <= TimeInTicks && TimeInTicks <= End.Ticks ? true : false;
    }
}

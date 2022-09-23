namespace AspCoreMetanit;


public class TimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}
public class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}

public class LongTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToLongTimeString();
}

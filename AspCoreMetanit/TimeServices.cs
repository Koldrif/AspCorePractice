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

// Adding Extension Methods

public static class ServiceProviderExstensions
{
    public static void AddTimeService(this IServiceCollection collection)
    {
        collection.AddTransient<TimeService>();
    }
}

public class TimeMessage
{
    private readonly ITimeService _timeService;

    public TimeMessage(ITimeService timeService)
    {
        _timeService = timeService;
    }

    public string GetTime() => _timeService.GetTime();
}
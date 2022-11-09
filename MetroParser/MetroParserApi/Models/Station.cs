using MetroParserApi.Interfaces;
using MetroParserApi.Services;

namespace MetroParserApi.Models
{
    public class Station
    {
        string Name { get; set; }
        StationDirection[] Directions { get; set; }

    }
    public class BaseSchedule : ISchedule
    {
        public TimeOnly[] Times { get; private set; }
    }
    public class WeekendTimes : BaseSchedule
    {
    }
    public class WorkingDaysTimes
    {
    }
}

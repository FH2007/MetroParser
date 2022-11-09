namespace MetroParserApi.Models
{
    public class StationDirection
    {
        public string DirectionStationName { get; set; }
        WeekendTimes[] WeekendTimes { get; set; }
        WorkingDaysTimes[] WorkingDaysTimes { get; set; }
    }
}

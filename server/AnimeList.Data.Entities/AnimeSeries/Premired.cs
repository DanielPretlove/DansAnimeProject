namespace AnimeList.Data.Entities.AnimeSeries
{
    public class Premired : DataEntitiy
    {
        public string SeasonalTitle { get; set; }
        public DateTime Year { get; set; }
        public int Order { get; set; }
    }
}
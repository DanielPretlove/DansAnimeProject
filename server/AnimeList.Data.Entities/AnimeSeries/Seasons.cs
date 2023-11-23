using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeList.Data.Entities.AnimeSeries
{
    public class Seasons : DataEntitiy
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public AnimeType SeriesType { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Premired Premired { get; set; }
        public SourceEnum Source { get; set; }
        public IList<Genre> Genre { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; }
        public int Ranked { get; set; }
        public int Popularity { get; set; }
        public int Order { get; set; } = 0;
        public RelatedAnimeTypeEnum RelatedAnime { get; set; }
    }
}

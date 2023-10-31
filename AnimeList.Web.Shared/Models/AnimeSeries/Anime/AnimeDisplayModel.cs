using AnimeList.Web.Shared.Models.AnimeSeries.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Web.Shared.Models.AnimeSeries.Anime
{
    public class AnimeDisplayModel : BaseModel
    {
        public IList<SeasonsDisplayModel> AnimeTitles { get; set; } = new List<SeasonsDisplayModel>();

    }
}

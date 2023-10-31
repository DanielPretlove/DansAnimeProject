using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Web.Shared.Models.AnimeSeries.Seasons
{
    public class SeasonsUpdateModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

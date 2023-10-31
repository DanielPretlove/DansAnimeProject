using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Data.Entities.AnimeSeries
{
    public class Anime : DataEntitiy
    {
        public IList<Seasons> AnimeTitles { get; set; } = new ObservableCollection<Seasons>();
    }
}

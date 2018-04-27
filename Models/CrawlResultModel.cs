using System.Collections.Generic;
using eDiscovery.Core;

namespace eDiscovery.Models
{
    public class CrawlResultModel
    {
        public List<CrawlResultViewModel> CrawlResultViewModels { get; set; }
        public SearchTerms searchTerms { get; set; }
        public string Name { get; set; }

        public CrawlResultModel()
        {
            CrawlResultViewModels = new List<CrawlResultViewModel>();
            searchTerms = new SearchTerms();
        }
    }

}
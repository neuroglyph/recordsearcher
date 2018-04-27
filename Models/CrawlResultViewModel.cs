using eDiscovery.Core;

namespace eDiscovery.Models
{
    public class CrawlResultViewModel
    {
        private readonly CrawlResult _crawlresult ;
       
        public CrawlResultViewModel(CrawlResult result)
        {
            _crawlresult = result;
        }

        public string Title { get { return _crawlresult.Title; }}
        public string Name { get { return _crawlresult.Name; } }
        public string Url { get { return _crawlresult.Url; } }
        public string Description { get { return _crawlresult.Description;  } }
        public string Source { get { return _crawlresult.Source;  } }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eDiscovery.Core;
using eDiscovery.Core.Crawlers;
using eDiscovery.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using WebGrease.Css.Extensions;

namespace eDiscovery.Controllers
{
    public class SearchController : ApiController
    {

        // GET api/searcch/5
         [HttpGet]
        public IEnumerable<CrawlResult> Get(string firstName, string lastName, string middleName, string dateOfBirth, string gender)
        {

             // convert results for dates
             DateTime dob;
             string birthdayInCorrectForm = string.Empty;
             if (DateTime.TryParse(dateOfBirth, out dob))
             {
                 birthdayInCorrectForm = dob.ToString("MM/dd/yyyy");
             }
      
            var searchTerms = new SearchTerms
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Gender =  (gender.ToLower().Contains("gender")) ? string.Empty : gender,
                DateOfBirth = birthdayInCorrectForm
            };

            CrawlResultModel crawlModel = new CrawlResultModel();
           
            var searchers = new List<ICrawler> { };

            searchers.Add( new MeckCoInquiryCrawler());
            searchers.Add(new NCDeptOfCorrectionsCrawler());
            searchers.Add(new BoardOfElectionsCrawler());

            var searcher = new Searcher(searchers);

            //var results = crawler.SubmitRequest(crawlResultModel.searchTerms);
            var results = searcher.Search(searchTerms);

             // may not be the best place, but appears that top lev is most expedient place to filter out based on middle name
            // return results.Where(r => r.MiddleName.ToLower() == searchTerms.MiddleName.ToLower());
             return results;
        }

        // POST api/searcch
        public void Post([FromBody]string value)
        {
        }

        // PUT api/searcch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/searcch/5
        public void Delete(int id)
        {
        }
    }
}

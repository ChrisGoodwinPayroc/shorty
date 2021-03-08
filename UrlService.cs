using System;
using System.Collections.Generic;
using System.Linq;
using shorty.Models;


namespace shorty
{

    public class UrlService : IUrlService
    {
        private static List<UrlModel> _database;

        public UrlService()
        {
            if (_database == null)
                _database = new List<UrlModel>();
        }

        public List<UrlModel> GetAll()
        {
            var urlModels = new List<UrlModel>();

            urlModels = _database.ToList();

            return urlModels;
        }

        public void UpdateCount(string shortUrl)
        {
            var matchingUrl = _database.FirstOrDefault(x => x.ShortUrl == shortUrl);

            if (matchingUrl != null)
                matchingUrl.ClickCount = matchingUrl.ClickCount + 1;
        }

        string IUrlService.GenerateUrl(string url)
        {
            if (_database.Any(x => string.Equals(x.LongUrl, url, System.StringComparison.OrdinalIgnoreCase)))
            {
                var matchUrl = _database.First(x => string.Equals(x.LongUrl, url, System.StringComparison.OrdinalIgnoreCase));
                return matchUrl.ShortUrl;
            }

            var newUrlModel = new UrlModel();

            newUrlModel.Id = _database.Any() ? _database.Max(x => x.Id) + 1 : 1;
            newUrlModel.DateGenerated = DateTime.UtcNow;
            newUrlModel.IsActive = true;
            newUrlModel.LongUrl = url;

            _database.Add(newUrlModel);

            return newUrlModel.ShortUrl;
        }

        string IUrlService.GetFullUrl(string id)
        {
            var matchingUrl = _database.FirstOrDefault(x => string.Equals(x.ShortUrl, id, StringComparison.OrdinalIgnoreCase));
            if (matchingUrl != null && matchingUrl.IsActive)
                return matchingUrl.LongUrl;

            return string.Empty;
        }
    }
}
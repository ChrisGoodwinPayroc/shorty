using System.Collections.Generic;
using shorty.Models;

namespace shorty
{
    public interface IUrlService
    {
        public string GenerateUrl(string url);

        public string GetFullUrl(string id);
        List<UrlModel> GetAll();

        void UpdateCount(string shortUrl);
    }
}
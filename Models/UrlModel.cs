using System;
using System.Text;

namespace shorty.Models
{
    public class UrlModel
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }

        public string ShortUrl
        {
            get
            {
                var idString = this.Id.ToString();

                var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(idString));

                return base64;
            }
        }

        public string LongUrl { get; set; }

        public DateTime DateGenerated { get; set; }

        public long ClickCount { get; set; }

    }
}
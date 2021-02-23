using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Helpers
{
    public class AppSettings
    {
        // Properties for JWT Token Signature
        public string Site { get; set; }
        public string Audience { get; set; }
        public string ExpireTime { get; set; }
        public string Secret { get; set; }
        public string Client_Url { get; set; }

        // Sendgrind
        public string SendGridKey { get; set; }
        public string SendGridUser { get; set; }
    }
}

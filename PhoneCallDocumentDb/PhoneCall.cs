using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCallDocumentDb
{
    public class PhoneCall
    {
        public string id { get; set; }

        public PhoneCallState State { get; set; } = PhoneCallState.Open;

        public DateTimeOffset OpenDate { get; set; } = DateTime.Now;

        public DateTimeOffset? EndDate { get; set; }

        public string Operator { get; set; }

        public Customer Customer { get; set; }
        public ProductRequest[] Products { get; set; }
        public SupportRequest[] Support { get; set; }
    }
}
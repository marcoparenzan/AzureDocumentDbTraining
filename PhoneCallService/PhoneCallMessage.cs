using PhoneCallService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCallService
{
    public class PhoneCallMessage
    {
        public PhoneCallMessageType Type { get; set; }
        public NewPhoneCall NewPhoneCall { get; set; }
        public ClosePhoneCall ClosePhoneCall { get; set; }
        public string Sender { get; set; }
    }
}
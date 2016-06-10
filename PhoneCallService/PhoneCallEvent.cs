using PhoneCallService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCallService
{
    public class PhoneCallEvent
    {
        public PhoneCallEventType Type { get; set; }
        public Guid PhoneCallId { get; set; }
    }
}
using System;

namespace PhoneCallService
{
    public class PhoneCallSupportDto
    {
        public Guid PhoneCallId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public string Details { get; set; }
        public DateTimeOffset OpenDate { get; set; }
        public string Operator { get; set; }
    }
}
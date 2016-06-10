using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneCallService
{
    public class NewPhoneCall
    {
        public CustomerInfo CustomerInfo { get; set; }
        public NewProduct[] Products { get; set; }
        public NewSupport[] Support { get; set; }
    }
}
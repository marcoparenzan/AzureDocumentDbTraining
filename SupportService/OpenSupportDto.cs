using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportService
{
    public class OpenSupportDto
    {
        public Guid SupportId { get; set; }
        public DateTimeOffset OpenDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEMail { get; set; }
        public string Details { get; set; }
    }
}
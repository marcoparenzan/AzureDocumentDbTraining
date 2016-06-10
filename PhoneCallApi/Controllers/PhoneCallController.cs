using Microsoft.Azure.Documents.Client;
using PhoneCallDocumentDb;
using PhoneCallService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using AutoMapper;
using System.Web.Http.Cors;

namespace PhoneCallApi.Controllers
{
    [EnableCors(origins: "http://localhost:15745", headers: "*", methods: "*")]
    public class PhoneCallController : ApiController
    {
        private IPhoneCallService _service;

        protected IPhoneCallService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new PhoneCallDocumentDbService();
                    _service.Operator = "PhoneCallApi";
                }
                return _service;
            }
        }

        [HttpPost]
        [ActionName("NewPhoneCall")]
        public async Task Handle(NewPhoneCall newPhoneCall)
        {
            await Service.HandleAsync(newPhoneCall);
        }

        [HttpPost]
        [ActionName("ClosePhoneCall")]
        public async Task Handle(ClosePhoneCall closePhoneCall)
        {
            await Service.HandleAsync(closePhoneCall);
        }
    }
}

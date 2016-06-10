using Microsoft.Azure.Documents.Client;
using SupportDocumentDb;
using SupportService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SupportApi.Controllers
{
    [EnableCors(origins: "http://localhost:15745", headers: "*", methods: "*")]
    public class SupportController : ApiController
    {
        private ISupportService _service;

        protected ISupportService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new SupportDocumentDbService();
                    _service.Operator = "SupportApi";
                }
                return _service;
            }
        }

        [HttpGet]
        [ActionName("OpenSupports")]
        public async Task<IEnumerable<OpenSupportDto>> GetOpenSupports()
        {
            return await Service.GetOpenSupportsAsync();
        }

        [HttpPost]
        [ActionName("CloseSupport")]
        public async Task Handle(CloseSupport closeSupport)
        {
            await Service.HandleAsync(closeSupport);
        }
    }
}

using AutoMapper;
using Microsoft.Azure.Documents.Client;
using SupportService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDocumentDb
{
    public class SupportDocumentDbService: ISupportService
    {
        public string Operator { get; set; }

        private DocumentClient _client;

        protected DocumentClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new DocumentClient(
                        new Uri(ConfigurationManager.AppSettings["DocumentDbEndPoint"])
                        , ConfigurationManager.AppSettings["DocumentDbAccountKey"]
                    );
                }
                return _client;
            }
        }

        protected string Collection()
        {
            return "Documents";
        }

        private MapperConfiguration _mapperConfiguration;
        private IMapper _mapper;

        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapperConfiguration = new MapperConfiguration(cfg => {
                    });
                    _mapper = _mapperConfiguration.CreateMapper();
                }
                return _mapper;
            }
        }

        protected T1 Map<T1>(object target)
        {
            return Mapper.Map<T1>(target);
        }

        async Task<IEnumerable<OpenSupportDto>> ISupportService.GetOpenSupportsAsync()
        {
            var sql = "SELECT pc.id as SupportId, pc.OpenDate, pc.Customer.Name AS CustomerName, pc.Customer.EMail AS CustomerEMail, s.Details FROM pc JOIN s IN pc.Support WHERE pc.EndDate = null";
            var query = Client.CreateDocumentQuery<OpenSupportDto>(UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["DocumentDbDatabaseName"], Collection()), sql);
            var all = query.ToArray();
            return all;
        }

        async Task ISupportService.HandleAsync(CloseSupport closeSupport)
        {
            var sql = "SELECT * FROM crm WHERE crm.id = '" + closeSupport.SupportId + "'";
            var response = Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(ConfigurationManager.AppSettings["DocumentDbDatabaseName"], Collection(), closeSupport.SupportId.ToString()));
            var resource = response.Result.Resource;
            resource.SetPropertyValue("EndDate", DateTime.Now);
            resource.SetPropertyValue("SupportDescription", closeSupport.Description);
            var documentCollectionLink = UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["DocumentDbDatabaseName"], "CRM");
            await Client.UpsertDocumentAsync(documentCollectionLink, resource);
        }

        Task ISupportService.NewOpenSupportAsync(Guid supportId, string customerName, string customerEMail, string details, DateTimeOffset openDate)
        {
            throw new NotImplementedException();
        }
    }
}

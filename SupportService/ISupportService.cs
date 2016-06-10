using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportService
{
    public interface ISupportService
    {
        string Operator { get; set; }
        Task<IEnumerable<OpenSupportDto>> GetOpenSupportsAsync();
        Task HandleAsync(CloseSupport closeSupport);
        Task NewOpenSupportAsync(Guid supportId, string customerName, string customerEMail, string details, DateTimeOffset openDate);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCallService
{
    public interface IPhoneCallService
    {
        string Operator { get; set; }
        Task<Guid> HandleAsync(NewPhoneCall newPhoneCall);
        Task HandleAsync(ClosePhoneCall closePhoneCall);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCallService
{
    public interface IPhoneCallReader
    {
        Task<PhoneCallSupportDto> GetSupportForPhoneCallAsync(Guid phoneCallId);
    }
}

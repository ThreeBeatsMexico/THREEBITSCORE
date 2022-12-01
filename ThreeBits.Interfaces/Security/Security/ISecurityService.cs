using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;

namespace ThreeBits.Interfaces.Security
{
    public interface ISecurityService
    {
        ProcessResult Authenticate(Credential item);

        TokenJwt CreaToken(Credential cred);
    }
}

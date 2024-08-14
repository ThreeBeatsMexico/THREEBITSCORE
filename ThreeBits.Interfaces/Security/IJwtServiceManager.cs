using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Interfaces.Security
{
	public interface IJwtServiceManager
	{
		string GenerateToken(string username, string name, string userid, string roleid, string Secret, int expireMinutes = 900);

		string GenerateTokenRefresh(string username, string name, string userid, string roleid, string stringtoken, string SecretRefresh, int expireMinutes = 5);
	}
}

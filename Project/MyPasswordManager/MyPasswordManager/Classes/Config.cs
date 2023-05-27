using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyPasswordManager.Classes
{
    public class Config
    {
        public Config() { }

        public string GetEncryptionKey()
        {
            return WindowsIdentity.GetCurrent().User.AccountDomainSid.Value;
        }
    }
}

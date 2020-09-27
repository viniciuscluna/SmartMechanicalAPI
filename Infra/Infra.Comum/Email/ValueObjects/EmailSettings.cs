using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Comum.Email.ValueObjects
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
    }
}

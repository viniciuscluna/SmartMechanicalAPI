using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Comum.Email.Interfaces
{
    public interface IEmailServico
    {
        void SendEmailAsync(string email, string subject, string message);

        Task<string> HTMLEmailAbertura();
    }
}

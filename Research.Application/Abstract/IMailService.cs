using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Application.Abstract
{
    public interface IMailService
    {
        Task SendEmail(string email, string name, string surname);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models.Repository.Testemunho
{
    public interface ITestemunhoRepository
    {
        List<Models.Testemunho> GetTestemunhos();
    }
}

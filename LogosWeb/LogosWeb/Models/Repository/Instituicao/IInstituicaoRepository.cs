using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models.Repository.Instituicao
{
    public interface IInstituicaoRepository
    {
        Models.Instituicao GetInstituicaoInfo();
        Models.Instituicao GetContatoInfo();
        Models.Instituicao GetValoresInfo();
    }
}

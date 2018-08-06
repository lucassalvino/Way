using System;
using System.Collections.Generic;
using System.Text;
using Way.infra.ManagerTables;
using Way.infra.Mapeadores;
using Way.infra.Persistencia;

namespace Way.infra.DefRepositories
{
    public class DefRepositorioPessoa : BaseManagerTable<MapPessoa>
    {
        public DefRepositorioPessoa(WayContext context) : base(context)
        {
            RealizaSet = true;
        }
    }
}

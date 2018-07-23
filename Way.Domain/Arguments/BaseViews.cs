using System;

namespace Way.Domain.Arguments
{
    public class BaseViews
    {
        public Guid IdEntidade { get; set; }

        public Guid IdSessao { get; set; }

        public bool Ativo { get; set; }
    }
}

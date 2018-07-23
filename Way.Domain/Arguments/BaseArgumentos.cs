using Newtonsoft.Json;
using System;

namespace Way.Domain.Arguments
{
    public class BaseArgumentos
    {
        public String Menssagem { get; set; }

        public String ErrorMessage { get; set; }

        public Boolean Error { get; set; }

        public Guid IdSessao { get; set; }

        public object Alertas { get; set; }

        public void DefineErro()
        {
            Error = true;
        }

        public void DefineSucess()
        {
            Error = false;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

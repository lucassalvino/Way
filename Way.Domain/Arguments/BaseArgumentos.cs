using Newtonsoft.Json;
using System;

namespace Way.Domain.Arguments
{
    public class BaseArgumentos
    {
        public String Menssagem { get; set; }

        public String Error { get; set; }

        public String Codigo { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

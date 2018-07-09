using BasisForDeveloper.NotificationPattern;
using Newtonsoft.Json;
using System;
namespace Way.Domain.Entities
{
    public class BaseEntidade : Notification
    {
        public Guid Id { get; set; }

        public Boolean Ativo { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
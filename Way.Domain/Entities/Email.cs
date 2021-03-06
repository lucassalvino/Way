﻿using System;

namespace Way.Domain.Entities
{
    public class Email : BaseEntidade
    {
        public String Endereco { get; set; }

        public bool Validado { get; set; }

        protected override void ExecuteValidation()
        {
            ValidEmail(this.Endereco);
        }
    }
}

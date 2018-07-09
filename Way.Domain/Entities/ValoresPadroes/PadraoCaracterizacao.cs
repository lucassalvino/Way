using System;
using System.Collections.Generic;
using System.Text;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class PadraoCaracterizacao
    {
        public static Guid Fisica
        {
            get
            {
                return new Guid("790A5419-7337-43C9-958D-10C682261FCE");
            }
        }

        public static Guid Juridica
        {
            get
            {
                return new Guid("6080D93D-E88B-4C99-87FB-A2F5ED2BB1C6");
            }
        }

        public static Guid Empresa
        {
            get
            {
                return new Guid("4CA03A19-7CCA-4834-8847-2D669585EDA7");
            }
        }

        public static Guid Aluno
        {
            get
            {
                return new Guid("5441C6A9-AB2D-40ED-9161-1D4F332AF6D0");
            }
        }

        public static Guid Motorista
        {
            get
            {
                return new Guid("3A3BB1EA-8165-451F-928E-AE5A46F81157");
            }
        }

        public static Guid Responsavel
        {
            get
            {
                return new Guid("64825686-2C37-4DDF-84B1-D843031ED051");
            }
        }
    }
}

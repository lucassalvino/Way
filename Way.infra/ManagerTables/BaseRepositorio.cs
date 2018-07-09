using System;
using Way.infra.Persistencia;

namespace Way.infra.ManagerTables
{
    public abstract class BaseRepositorio<TYPE>
    {
        private WayContext _context;

        public Boolean RealizaSet { get; set; }

        protected WayContext DBContext
        {
            get
            {
                if (_context == null)
                    throw new Exception("Um serviço não pode ser criado sem uma instancia do contexto");
                return _context;
            }
        }

        public BaseRepositorio(WayContext context)
        {
            _context = context;
        }
    }
}

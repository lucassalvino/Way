using System;
using Way.infra.Mapeadores;
using Way.infra.Persistencia;

namespace Way.infra.ManagerTables
{
    public class BaseManagerTable<TYPE> : BaseRepositorio<TYPE>
        where TYPE : BaseMapEntidade
    {
        public BaseManagerTable(WayContext context) : base(context)
        {
        }

        protected virtual void _Put(TYPE data, Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual TYPE GetById(Guid id)
        {
            var DbSet = DBContext.Set<TYPE>();
            TYPE data = DbSet.Find(id);
            if (data == null) throw new Exception($"Não foi possível encontrar um registro do tipo [{typeof(TYPE)}] com ID = [{id}]");
            return data;
        }

        public virtual void Delete(Guid id)
        {
            if (RealizaSet) throw new Exception("Esta tabela não pode ser alterada. Somente Leitura.");
            TYPE val = GetById(id);
            val.Ativo = false;
            DBContext.SaveChanges();
        }

        public virtual void Delete(Guid[] id)
        {
            foreach (Guid a in id)
                Delete(a);
        }

        public virtual void Put(TYPE data, Guid id)
        {
            if (RealizaSet) throw new Exception("Esta tabela não pode ser alterada. Somente Leitura.");
            if (data == null)
            {
                data = GetDefaultRegistro();
                id = data.Id;
            }
            _Put(data, id);
            DBContext.SaveChanges();
        }

        public virtual Guid Post(TYPE data)
        {
            if (RealizaSet) throw new Exception("Esta tabela não pode ser alterada. Somente Leitura.");

            if (data == null) data = GetDefaultRegistro();

            TYPE _tes = DBContext.Set<TYPE>().Find(data.Id);

            if (_tes != null)
            {
                Put(data, _tes.Id);
                return _tes.Id;
            }

            var DbSet = DBContext.Set<TYPE>();
            DbSet.Add(data);
            DBContext.SaveChanges();
            return data.Id;
        }

        public virtual TYPE GetDefaultRegistro()
        {
            throw new Exception($"Nao he possivel salvar um dado vazio. Type: [{typeof(TYPE)}]");
        }
    }
}

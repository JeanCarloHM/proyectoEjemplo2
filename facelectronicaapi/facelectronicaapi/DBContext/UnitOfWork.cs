using System;
using FacElectronicaApi.DBContext.Repositories;

namespace FacElectronicaApi.DBContext
{
    /// <summary>
    /// Administrador de los respositorio de la base de datos
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Conexión a la base de datos con Entity Framework
        /// </summary>
        protected FacturacionDBContext _Context;

        public UnitOfWork()
        {
            _Context = new FacturacionDBContext();
        }

        /// <summary>
        /// Libera la conexión a la base de datos
        /// </summary>
        public void Dispose()
        {
            _Context.Dispose();
            _Context = null;
        }

        /// <summary>
        /// Guarda cambios en la base de datos
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        #region Repositorios

        private EmpresasRepository _EmpresasRepository;
        public EmpresasRepository EmpresasRepository
        {
            get
            {
                if (_EmpresasRepository == null)
                {
                    _EmpresasRepository = new EmpresasRepository(_Context);
                }
                    
                return _EmpresasRepository;
            }
        }

        #endregion
    }
}
using FacElectronicaApi.DBContext.Entities;
using System;
using System.Linq;

namespace FacElectronicaApi.DBContext.Repositories
{
    /// <summary>
    /// Repositorio utilizado para administrar las empresas del sistema
    /// </summary>
    public class EmpresasRepository : Repository<EmpresasEntity>
    {
        public EmpresasRepository(FacturacionDBContext context)
            : base(context)
        { }

        /// <summary>
        /// Consulta una empresa con su Nit
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public EmpresasEntity Obtener(Decimal nit)
        {
            return Items.Where(m => m.Nit == nit).FirstOrDefault();
        }
    }
}
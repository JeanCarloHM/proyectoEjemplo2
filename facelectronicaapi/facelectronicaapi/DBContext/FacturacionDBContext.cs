using FacElectronicaApi.DBContext.Entities;
using System.Data.Entity;

namespace FacElectronicaApi.DBContext
{
    public class FacturacionDBContext : DbContext
    {
        public FacturacionDBContext()
            : base("name=DBContext")
        { }

        public virtual DbSet<ClientesEntity> Clientes { get; set; }
        public virtual DbSet<EmpresasEntity> Empresas { get; set; }
        public virtual DbSet<FacturasEntity> Facturas { get; set; }
        public virtual DbSet<FacturasDetEntity> FacturasDet { get; set; }
    }
}
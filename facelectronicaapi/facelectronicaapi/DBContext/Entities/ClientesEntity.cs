using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacElectronicaApi.DBContext.Entities
{
    [Table("CLIENTES", Schema = "dbo")]
    public partial class ClientesEntity
    {
        [Key]
        [Column("CLI_EMPRESA", Order = 0, TypeName = "numeric")]
        public Decimal NitEmpresa { get; set; }

        [Key]
        [Column("CLI_NIT", Order = 1, TypeName = "numeric")]
        public Decimal Nit { get; set; }

        [Column("CLI_DV")]
        public Byte? DigitoVerificacion { get; set; }

        [StringLength(100)]
        [Column("CLI_RAZON_SOCIAL")]
        public String RazonSocial { get; set; }

        [StringLength(100)]
        [Column("CLI_NOMBRE_COMERCIAL")]
        public String NombreComercial { get; set; }

        [StringLength(100)]
        [Column("CLI_DIRECCION")]
        public String Direccion { get; set; }

        [StringLength(20)]
        [Column("CLI_TELEFONO")]
        public String Telefono { get; set; }

        [StringLength(50)]
        [Column("CLI_CIUDAD")]
        public String Ciudad { get; set; }

        [StringLength(100)]
        [Column("CLI_EMAIL")]
        public String Email { get; set; }
    }
}

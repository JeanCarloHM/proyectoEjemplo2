using FacElectronicaApi.DBContext.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacElectronicaApi.DBContext.Entities
{
    [Table("EMPRESAS", Schema = "dbo")]
    public partial class EmpresasEntity
    {
        [Key]
        [Column("EMP_NIT", TypeName = "numeric")]
        public Decimal Nit { get; set; }

        [Column("EMP_DV", TypeName = "numeric")]
        public Decimal? DigitoVerificacion { get; set; }

        [StringLength(100)]
        [Column("EMP_RAZON_SOCIAL")]
        public String RazonSocial { get; set; }

        [StringLength(100)]
        [Column("EMP_NOMBRE_COMERCIAL")]
        public String NombreComercial { get; set; }

        [StringLength(100)]
        [Column("EMP_DIRECCION")]
        public String Direccion { get; set; }

        [StringLength(20)]
        [Column("EMP_TELEFONO")]
        public String Telefono { get; set; }

        [StringLength(20)]
        [Column("EMP_FAX")]
        public String Fax { get; set; }

        [StringLength(50)]
        [Column("EMP_CIUDAD")]
        public String Ciudad { get; set; }

        [StringLength(50)]
        [Column("EMP_LOGO")]
        public String Logo { get; set; }

        [StringLength(100)]
        [Column("EMP_EMAIL")]
        public String Email { get; set; }

        [StringLength(100)]
        [Column("EMP_SITIO_WEB")]
        public String SitioWeb { get; set; }

        [StringLength(100)]
        [Column("EMP_FORMATO_IMPRESION")]
        public String FormatoImpresion { get; set; }

        [Column("EMP_REGIMEN_CONTRIBUTIVO", TypeName ="numeric")]
        public Decimal? RegimenContributivo { get; set; }

        [Column("EMP_ESTADO", TypeName = "numeric")]
        public EstadosEmpresasType Estado { get; set; }

        [StringLength(20)]
        [Column("EMP_PASSWORD")]
        public String Password { get; set; }

        [Column("EMP_FIRMA_ELECTRONICA")]
        public Byte[] FirmaElectronica { get; set; }
    }
}

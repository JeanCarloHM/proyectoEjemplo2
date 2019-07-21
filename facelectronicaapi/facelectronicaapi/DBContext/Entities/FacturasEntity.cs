using FacElectronicaApi.DBContext.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FacElectronicaApi.DBContext.Entities
{
    [Table("FACTURAS", Schema = "dbo")]
    public partial class FacturasEntity
    {
        [Key]
        [Column("FAC_EMPRESA", Order = 0, TypeName = "numeric")]
        public Decimal NitEmpresa { get; set; }

        [Key]
        [Column("FAC_NUMERO", Order = 1, TypeName = "numeric")]
        public Decimal Numero { get; set; }

        [Required]
        [Column("FAC_FECHA_EXPEDICION")]
        public DateTime FechaExpedicion { get; set; }

        [Column("FAC_FECHA_VENCIMIENTO")]
        public DateTime FechaVencimiento { get; set; }

        [StringLength(10)]
        [Column("FAC_FORMA_PAGO")]
        public String FormaPago { get; set; }

        [Column("FAC_ESTADO", TypeName = "numeric")]
        public EstadosFacturasType Estado { get; set; }

        [StringLength(4000)]
        [Column("FAC_OBSERVACIONES")]
        public String Observaciones { get; set; }

        [Column("FAC_VALOR", TypeName = "numeric")]
        public Decimal? SubTotalFactura { get; set; }

        [Column("FAC_VALOR_IVA", TypeName = "numeric")]
        public Decimal? TotalValorIva { get; set; }

        [Column("FAC_VALOR_NETO", TypeName = "numeric")]
        public Decimal? TotalValorNeto { get; set; }

        [StringLength(100)]
        [Column("FAC_CUFE")]
        public String CodigoCUFE { get; set; }

        [Column("FAC_FECHA_CREACION")]
        public DateTime FechaCreacion { get; set; }
    }
}

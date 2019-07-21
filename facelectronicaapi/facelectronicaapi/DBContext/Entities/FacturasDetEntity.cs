using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FacElectronicaApi.DBContext.Entities
{
    [Table("FACTURAS_DET", Schema = "dbo")]
    public partial class FacturasDetEntity
    {
        [Key]
        [Column("DFAC_EMPRESA", Order = 0, TypeName = "numeric")]
        public Decimal NitEmpresa { get; set; }

        [Key]
        [Column("DFAC_NUMERO", Order = 1, TypeName = "numeric")]
        public Decimal Numero { get; set; }

        [Key]
        [Column("DFAC_COD_PRODUCTO", Order = 2)]
        [StringLength(20)]
        public String CodigoProducto { get; set; }

        [StringLength(500)]
        [Column("DFAC_DESC_PRODUCTO")]
        public String DescripcionProducto { get; set; }

        [Column("DFAC_VALOR_UNITARIO", TypeName = "numeric")]
        public Decimal? ValorUnitario { get; set; }

        [Column("DFAC_PORCENTAJE_IVA", TypeName = "numeric")]
        public Decimal? PorcentajeIva { get; set; }

        [Column("DFAC_VALOR_IVA", TypeName = "numeric")]
        public Decimal? ValorIva { get; set; }

        [Column("DFAC_CANTIDAD", TypeName = "numeric")]
        public Decimal? Cantidad { get; set; }

        [Column("DFAC_VALOR_TOTAL", TypeName = "numeric")]
        public Decimal? ValorTotal { get; set; }
    }
}

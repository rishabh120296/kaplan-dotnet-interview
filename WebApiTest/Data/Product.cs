using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Data
{
    public partial class Product
    {
        [SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductID { get; set; }

        [Required] [StringLength( 100 )] public string Name { get; set; }

        [Column( TypeName = "money" )] public decimal UnitPrice { get; set; }

        [SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

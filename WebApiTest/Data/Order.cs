using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Data
{
    public partial class Order
    {
        [SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderID { get; set; }

        public int OrderingPersonID { get; set; }

        [Column( TypeName = "datetime2" )] public DateTime CreatedAt { get; set; }

        [SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual Person Person { get; set; }
    }
}

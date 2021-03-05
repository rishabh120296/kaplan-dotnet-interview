using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Data
{
    [Table( "Persons" )]
    public partial class Person
    {
        [SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
        public Person()
        {
            Orders = new HashSet<Order>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int PersonID { get; set; }

        [Required] [StringLength( 50 )] public string FirstName { get; set; }

        [Required] [StringLength( 50 )] public string LastName { get; set; }

        [SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<Order> Orders { get; set; }

        [SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

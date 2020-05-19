namespace CP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plane")]
    public partial class Plane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plane()
        {
            Flight = new HashSet<Flight>();
        }
        public Plane(string name, int seats, int cruisSpeed, int maxHeight)
        {
            Name = name;
            Seats = seats;
            CruisingSpeed = cruisSpeed;
            MaxHeight = maxHeight;
        }
        [Key]
        public int IdPlane { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int Seats { get; set; }

        public int CruisingSpeed { get; set; }

        public int MaxHeight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}

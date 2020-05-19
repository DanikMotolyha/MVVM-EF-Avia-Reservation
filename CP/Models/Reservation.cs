namespace CP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        public int IdReservation { get; set; }

        public int? IdFlight { get; set; }

        public int? IdUser { get; set; }

        public int YourSeat { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual User User { get; set; }
    }
}

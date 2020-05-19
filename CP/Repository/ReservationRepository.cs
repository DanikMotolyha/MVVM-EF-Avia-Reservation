using System.Collections.Generic;
using System.Data.Entity;

namespace CP.Repository
{
    class ReservationRepository
    {
        private AviaDatabase db;
        public ReservationRepository(AviaDatabase context)
        { this.db = context; }
        public IEnumerable<Reservation> GetAll()
        { return db.Reservation; }
        public Reservation Get(int id)
        { return db.Reservation.Find(id); }
        public void Create(Reservation reservation)
        { db.Reservation.Add(reservation); }
        public void Update(Reservation reservation)
        { db.Entry(reservation).State = EntityState.Modified; }
        public void Delete(int id)
        {
            Reservation reservation = db.Reservation.Find(id);
            if (reservation != null)
                db.Reservation.Remove(reservation);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Repository
{
    class FlightRepository
    {
        private AviaDatabase db;
        public FlightRepository(AviaDatabase context)
        { this.db = context; }
        public IEnumerable<Flight> GetAll()
        { return db.Flight; }
        public Flight Get(int id)
        { return db.Flight.Find(id); }
        public void Create(Flight flight)
        { db.Flight.Add(flight); }
        public void Update(Flight flight)
        { db.Entry(flight).State = EntityState.Modified; }
        public void Delete(int id)
        {
            Flight flight = db.Flight.Find(id);
            if (flight != null)
                db.Flight.Remove(flight);
        }
    }
}

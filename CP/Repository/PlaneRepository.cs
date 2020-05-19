using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CP.Repository
{
    class PlaneRepository
    {
        private AviaDatabase db;
        public PlaneRepository(AviaDatabase context)
        { this.db = context; }
        public IEnumerable<Plane> GetAll()
        { return db.Plane; }
        public Plane Get(int id)
        { return db.Plane.Find(id); }
        public List<Plane> ToList()
        { return db.Plane.ToList(); }
        public IEnumerable ToBindingList()
        { return db.Plane.Local.ToBindingList(); }
        public void Create(Plane plane)
        { db.Plane.Add(plane); }
        public void Update(Plane plane)
        { db.Entry(plane).State = EntityState.Modified; }
        public void Delete(int id)
        {
            Plane plane= db.Plane.Find(id);
            if (plane != null)
                db.Plane.Remove(plane);
        }
    }
}

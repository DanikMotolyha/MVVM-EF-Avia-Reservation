using System.Collections.Generic;
using System.Data.Entity;

namespace CP.Repository
{
    class UserRepository : IRepository<User>
    {
        private AviaDatabase db;
        public UserRepository(AviaDatabase context)
        { this.db = context; }
        public IEnumerable<User> GetAll()
        { return db.User; }
        public User Get(int id)
        { return db.User.Find(id); }
        public void Create(User user)
        { db.User.Add(user); }
        public void Update(User user)
        { db.Entry(user).State = EntityState.Modified; }
        public void Delete(int id)
        {
            User user = db.User.Find(id);
            if (user != null)
                db.User.Remove(user);
        }
    }
}
    

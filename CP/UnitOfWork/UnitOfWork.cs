using CP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.UnitOfWork
{
    class UnitOfWork : IDisposable
    {
        private AviaDatabase _db;
        private UserRepository _userRepository;
        private PlaneRepository _planeRepository;
        private FlightRepository _flightRepository;
        private ReservationRepository _reservationRepository;
        public UnitOfWork()
        {
            _db = new AviaDatabase();
        }
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;                
            }
        }
        public PlaneRepository PlaneRepository
        {
            get
            {
                if (_planeRepository == null)
                    _planeRepository = new PlaneRepository(_db);
                return _planeRepository;
            }
        }
        public FlightRepository FlightRepository
        {
            get
            {
                if (_flightRepository == null)
                    _flightRepository = new FlightRepository(_db);
                return _flightRepository;
            }
        }
        public ReservationRepository ReservationRepository
        {
            get
            {
                if (_reservationRepository == null)
                    _reservationRepository = new ReservationRepository(_db);
                return _reservationRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

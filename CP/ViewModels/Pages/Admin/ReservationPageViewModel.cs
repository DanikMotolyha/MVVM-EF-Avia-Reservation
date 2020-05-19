using CP.Command;
using CP.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using CP.Views;
namespace CP.ViewModels.Pages
{
    class ReservationPageViewModel : NotifyPropertyChanged
    {
        private Reservation _selectedReservation;
        private int _userFilter;
        public int UserFilter
        {
            get => _userFilter;
            set
            {
                _userFilter = value;
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Reservations = unitOfWork.ReservationRepository.GetAll()
                        .Where(a => a.IdUser == value)
                        .ToList();
                }
                OnPropertyChanged("IdFilter");
            }
        }
        private int _flightFilter;
        public int FlightFilter
        {
            get => _flightFilter;
            set
            {
                _flightFilter = value;
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Reservations = unitOfWork.ReservationRepository.GetAll()
                        .Where(a => a.IdFlight == value)
                        .ToList();
                }
                OnPropertyChanged("FlightFilter");
            }
        }
        private int _reservationFilter;
        public int ReservationFilter
        {
            get => _reservationFilter;
            set
            {
                _reservationFilter = value;
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Reservations = unitOfWork.ReservationRepository.GetAll()
                        .Where(a => a.IdReservation == value)
                        .ToList();
                }
                OnPropertyChanged("FlightFilter");
            }
        }
        public Reservation SelectedReservation
        {
            get => _selectedReservation;
            set
            {
                _selectedReservation = value;
                OnPropertyChanged("SelectedReservation");
            }
        }
        private List<Reservation> _reservations;
        public List<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged("Reservations");
            }
        }
        public ReservationPageViewModel()
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                Reservations = unitOfWork.ReservationRepository.GetAll().ToList();
            }
        }

        private RelayCommand _deletePlaneCommand;
        private RelayCommand _updatePlaneCommand;

        public RelayCommand UpdatePlaneCommand => _updatePlaneCommand ??
                 (_updatePlaneCommand = new RelayCommand(obj => ExexuteUpdatePlaneCommand()));
        public RelayCommand DeletePlaneCommand => _deletePlaneCommand ??
                  (_deletePlaneCommand = new RelayCommand(obj => ExexuteDeletePlaneCommand()));

        private void ExexuteDeletePlaneCommand()
        {
            try
            {
                if (SelectedReservation == null)
                    throw new Exception("Не выбрана бронь");
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    unitOfWork.ReservationRepository.Delete(SelectedReservation.IdReservation);
                    unitOfWork.Save();
                    if (unitOfWork.ReservationRepository.GetAll().Count() != 0)
                        SelectedReservation = unitOfWork.ReservationRepository.GetAll().Last();
                    else
                        SelectedReservation = null;
                    Reservations = unitOfWork.ReservationRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
                message.Show();
            }
        }
        private void ExexuteUpdatePlaneCommand()
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                Reservations = unitOfWork.ReservationRepository.GetAll().ToList();
            }
        }
    }
}

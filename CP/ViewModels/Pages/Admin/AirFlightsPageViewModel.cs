using CP.Command;
using CP.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Views;
using CP.Views.Pages;

namespace CP.ViewModels
{
    class AirFlightsPageViewModel : NotifyPropertyChanged
    {
        private Flight _selectedAirFlights;
        public Flight SelectedAirFlights
        {
            get => _selectedAirFlights;
            set
            {
                _selectedAirFlights = value;
                OnPropertyChanged("SelectedAirFlights");
            }
        }
        private List<Flight> _airFlights;
        public List<Flight> AirFlights
        {
            get => _airFlights;
            set
            {
                _airFlights = value;
                OnPropertyChanged("AirFlights");
            }
        }
        public AirFlightsPageViewModel()
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                AirFlights = unitOfWork.FlightRepository.GetAll().ToList();
            }
        }
        private RelayCommand _deleteFlightCommand;
        private RelayCommand _addFlightCommand;
        private RelayCommand _changeFlightCommand;
        private RelayCommand _updateFlightCommand;
        public RelayCommand AddFlightCommand => _addFlightCommand??
                   (_addFlightCommand = new RelayCommand(obj => ExexuteAddFlightCommand()));
        public RelayCommand UpdateFlightCommand => _updateFlightCommand ??
                  (_updateFlightCommand = new RelayCommand(obj => ExexuteUpdateFlightCommand()));
        public RelayCommand ChangeFlightCommand => _changeFlightCommand ??
                  (_changeFlightCommand = new RelayCommand(obj => ExexuteChangeFlightCommand()));
        public RelayCommand DeleteFlightCommand => _deleteFlightCommand ??
                  (_deleteFlightCommand = new RelayCommand(obj => ExexuteDeleteFlightCommand()));
        private void ExexuteDeleteFlightCommand()
        {
            try
            {
                if (SelectedAirFlights == null)
                    throw new Exception("Не выбран самолет");
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    if (unitOfWork.ReservationRepository.GetAll().Where(a => a.IdFlight == _selectedAirFlights.IdFlight).Count() != 0)
                        throw new Exception("Выбраный рейс\nнельзя удалить.\nОн уже используется");
                    unitOfWork.FlightRepository.Delete(SelectedAirFlights.IdFlight);
                    unitOfWork.Save();
                    if (unitOfWork.FlightRepository.GetAll().Count() != 0)
                        SelectedAirFlights = unitOfWork.FlightRepository.GetAll().Last();
                    else
                        SelectedAirFlights = null;
                    AirFlights = unitOfWork.FlightRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
                message.Show();
            }
        }
        private void ExexuteAddFlightCommand()
        {
            /*AirFlightReg airFlightReg= new AirFlightReg(-1);
            airFlightReg.Show();*/
        }
        private void ExexuteChangeFlightCommand()
        {
            try
            {
               if (_selectedAirFlights == null)
                    throw new Exception("Необходимо выбрать рейс");
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    if (unitOfWork.ReservationRepository.GetAll().Where(a => a.IdFlight == _selectedAirFlights.IdFlight).Count() != 0)
                        throw new Exception("Выбраный рейс\nнельзя изменить.\nОн уже используется");
                }
                AirFlightReg airFlightReg = new AirFlightReg(_selectedAirFlights.IdFlight);
                airFlightReg.Show();
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
                message.Show();
            }
        }
        private void ExexuteUpdateFlightCommand()
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                AirFlights = unitOfWork.FlightRepository.GetAll().ToList();
            }
        }

    }
}

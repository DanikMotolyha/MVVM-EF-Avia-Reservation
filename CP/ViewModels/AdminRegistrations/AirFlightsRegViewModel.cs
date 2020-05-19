using CP.Other;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CP.ViewModels.AdminRegistrations
{
    class AirFlightsRegViewModel : NotifyPropertyChanged
    {
        public AirFlightsRegViewModel(int idFlight)
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                Flight flight = unitOfWork.FlightRepository.Get(idFlight);
                DateStart = flight.DateStart;
                DateEnd = flight.DateEnd;
                Price = flight.Price;
                FirstCity = flight.FirstCity;
                SecondCity = flight.SecondCity;
                SelectedIdPlane = flight.Plane.IdPlane;
                PlanesId = unitOfWork.PlaneRepository.GetAll()
                    .Select(a=>a.IdPlane).ToList();
            }
        }
        private List<int> _planesId;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private int _price;
        private string _firstCity;
        private string _secondCity;
        private Plane _plane;
        public DateTime DateStart
        {
            get => _dateStart;
            set
            {
                _dateStart = value;
                OnPropertyChanged("DateStart");
            }
        }
        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                OnPropertyChanged("DateEnd");
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public string FirstCity
        {
            get => _firstCity;
            set
            {
                _firstCity = value;
                OnPropertyChanged("FirstCity");
            }
        }
        public string SecondCity
        {
            get => _secondCity;
            set
            {
                _secondCity = value;
                OnPropertyChanged("SecondCity");
            }
        }
        private int _selectedIdPlane;
        public int SelectedIdPlane
        {
            get => _selectedIdPlane;
            set
            {
                _selectedIdPlane = value;
                OnPropertyChanged("SelectedIdPlane");
            }
        }
        public List<int> PlanesId
        {
            get => _planesId;
            set
            {
                _planesId = value;
                OnPropertyChanged("PlanesId");
            }
        }
    }
}

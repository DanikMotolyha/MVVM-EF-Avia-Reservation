using CP.Command;
using CP.Other;
using CP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CP.ViewModels
{
    class PlainRegViewModel : NotifyPropertyChanged
    {
        private string _name;
        private int _seats;
        private int _cruisingSpeed;
        private int _maxHeight;
        private int _idplane;
        public PlainRegViewModel(int idPlain)
        {
            _idplane = idPlain;
            if (_idplane != -1)
            {
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Plane plane = unitOfWork.PlaneRepository.Get(_idplane);
                    Name = plane.Name;
                    Seats = plane.Seats;
                    CruisingSpeed = plane.CruisingSpeed;
                    MaxHeight = plane.MaxHeight;
                }
            }
        }
        private RelayCommand _closeWindowCommand;
        public new RelayCommand CloseWindowCommand => _closeWindowCommand ??
                  (_closeWindowCommand = new RelayCommand(obj =>
                  {
                      Window window = (Window)obj;
                      window.Close();
                  }));
        private RelayCommand _addPlaneCommand;
        public RelayCommand AddPlaneCommand => _addPlaneCommand ??
                  (_addPlaneCommand = new RelayCommand(obj => ExexuteAddPlaneCommand(obj)));
        private void ExexuteAddPlaneCommand(object obj)
        {
            try
            {
                Window window = (Window)obj;
                if (_name == null || _name == "" || _seats == 0 || _cruisingSpeed == 0 || _maxHeight == 0)
                    throw new Exception("Все поля\nнеобходимо заполнить!");
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    if (_idplane != -1)
                    {
                        Plane plane = unitOfWork.PlaneRepository.Get(_idplane);
                        if (unitOfWork.PlaneRepository.GetAll().Where(a => a.Name == _name).Count() == 1
                            && plane.Name != Name)
                            throw new Exception("Такой самолет уже существует\nВыберите другое имя");
                        plane.Name = Name;
                        if (plane.Seats > Seats)
                        {
                            IEnumerable<int> Flight = unitOfWork.FlightRepository.GetAll()
                                .Where(a => a.IdPlane == plane.IdPlane)
                                .Select(a => a.IdFlight);
                            foreach (int idFlightCurrentPlane in Flight)
                            {
                                if (unitOfWork.ReservationRepository.GetAll()
                                     .Where(a => a.IdFlight == idFlightCurrentPlane)
                                     .Where(a => a.YourSeat > Seats)
                                     .Select(a => a.YourSeat)
                                     .Count() != 0)
                                    throw new Exception("Недопустимо\nизменение вместимости\nМестa забронированы");
                            }
                        }
                        plane.Seats = Seats;
                        plane.CruisingSpeed = CruisingSpeed;
                        plane.MaxHeight = MaxHeight;
                        unitOfWork.Save();
                        window.Close();
                    }
                    else
                    {
                        if (unitOfWork.PlaneRepository.GetAll().Where(a => a.Name == _name).Count() == 1)
                            throw new Exception("Такой самолет уже существует\nВыберите другое имя");
                        unitOfWork.PlaneRepository.Create(new Plane(Name, Seats, CruisingSpeed, MaxHeight));
                        unitOfWork.Save();
                        window.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
                message.Show();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Seats
        {
            get => _seats;
            set
            {
                _seats = value;
                OnPropertyChanged("Seats");
            }
        }
        public int CruisingSpeed
        {
            get => _cruisingSpeed;
            set
            {
                _cruisingSpeed = value;
                OnPropertyChanged("CruisingSpeed");
            }
        }
        public int MaxHeight
        {
            get => _maxHeight;
            set
            {
                _maxHeight = value;
                OnPropertyChanged("MaxHeight");
            }
        }
    }
}

using CP.Command;
using CP.Other;
using CP.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CP.ViewModels
{
    class PlainsPageViewModel : NotifyPropertyChanged
    {
        private Plane _selectedPlane;
        private string _nameFilter;
        private int _idFilter;
        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                _nameFilter = value;
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Planes = unitOfWork.PlaneRepository.GetAll().Where(a=>a.Name.StartsWith(value)).ToList();
                }
                OnPropertyChanged("NameFilter");
            }
        }
        public int IdFilter
        {
            get => _idFilter;
            set
            {
                _idFilter = value;
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Planes = unitOfWork.PlaneRepository.GetAll()
                        .Where(a=>a.IdPlane == value)
                        .ToList();
                }
                OnPropertyChanged("IdFilter");
            }
        }
        public Plane SelectedPlane
        {
            get => _selectedPlane;
            set
            {
                _selectedPlane = value;
                OnPropertyChanged("SelectedPlane");
            }
        }
        private List<Plane> _planes;
        public List<Plane> Planes
        {
            get => _planes;
            set
            {
                _planes = value;
                OnPropertyChanged("Planes");
            }
        }
        public PlainsPageViewModel()
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                Planes = unitOfWork.PlaneRepository.GetAll().ToList();
            }
        }
        private RelayCommand _deletePlaneCommand;
        private RelayCommand _addPlaneCommand;
        private RelayCommand _changePlaneCommand;
        private RelayCommand _updatePlaneCommand;
        public RelayCommand AddPlaneCommand => _addPlaneCommand ??
                  (_addPlaneCommand = new RelayCommand(obj => ExexuteAddPlaneCommand()));
        public RelayCommand UpdatePlaneCommand => _updatePlaneCommand ??
                  (_updatePlaneCommand = new RelayCommand(obj => ExexuteUpdatePlaneCommand()));
        public RelayCommand ChangePlaneCommand => _changePlaneCommand ??
                  (_changePlaneCommand = new RelayCommand(obj => ExexuteChangePlaneCommand()));
        public RelayCommand DeletePlaneCommand => _deletePlaneCommand ??
                  (_deletePlaneCommand = new RelayCommand(obj => ExexuteDeletePlaneCommand()));
        private void ExexuteDeletePlaneCommand()
        {
            try
            {
                if (SelectedPlane == null)
                    throw new Exception("Не выбран самолет");
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    if (unitOfWork.FlightRepository.GetAll().Where(a => a.Plane.IdPlane == _selectedPlane.IdPlane).Count() != 0)
                        throw new Exception("Выбраный самолет\nнельзя удалить.\nОн используется в рейсах");
                    unitOfWork.PlaneRepository.Delete(SelectedPlane.IdPlane);
                    unitOfWork.Save();
                    if (unitOfWork.PlaneRepository.GetAll().Count() != 0)
                        SelectedPlane = unitOfWork.PlaneRepository.GetAll().Last();
                    else
                        SelectedPlane = null;
                    Planes = unitOfWork.PlaneRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                Message message = new Message(ex.Message);
                message.Show();
            }
        }
        private void ExexuteAddPlaneCommand()
        {
            PlainReg plainReg = new PlainReg(-1);
            plainReg.Show();
        }
        private void ExexuteChangePlaneCommand()
        {
            try
            {
                if (_selectedPlane == null)
                    throw new Exception("Необходимо выбрать самолет");
                PlainReg plainReg = new PlainReg(_selectedPlane.IdPlane);
                plainReg.Show();
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
                Planes = unitOfWork.PlaneRepository.GetAll().ToList();
            }
        }

    }
}

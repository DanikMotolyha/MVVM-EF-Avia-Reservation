using System;
using System.Collections.Generic;
using System.Linq;
using CP.Command;
using CP.Other;
using CP.Views;

namespace CP.ViewModels
{
    class UsersPageViewModel : NotifyPropertyChanged
    {
        private string _nameFilter;
        private int _idFilter;
        private List<User> _users;
        private User _selectedUser;
        
        public UsersPageViewModel()
        {
            using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
            {
                Users = unitOfWork.UserRepository.GetAll().ToList();
            }
        }
        private RelayCommand _deleteUserCommand;
        private RelayCommand _updateUserCommand;
        public RelayCommand DeleteUserCommand => _deleteUserCommand ??
                  (_deleteUserCommand = new RelayCommand(obj => ExexuteDeleteUserCommand()));
        public RelayCommand UpdateUserCommand => _updateUserCommand ??
                (_updateUserCommand = new RelayCommand(obj => ExexuteUpdatePlaneCommand()));
        private void ExexuteDeleteUserCommand()
        {
            try
            {
                if (SelectedUser.IdUser == 0)
                    throw new Exception("Нельзя удалить\nадминистратора");
                if (SelectedUser == null)
                    throw new Exception("Необходимо выбрать пользователя");
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    if (unitOfWork.ReservationRepository.GetAll().Where(a=>a.IdUser == SelectedUser.IdUser).Count() != 0)
                        throw new Exception("Выбранного пользователя\nнельзя удалить.\nОн забронировал рейс");
                    unitOfWork.UserRepository.Delete(SelectedUser.IdUser);
                    unitOfWork.Save();
                    SelectedUser = unitOfWork.UserRepository.GetAll().Last();
                    Users = unitOfWork.UserRepository.GetAll().ToList();
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
                Users = unitOfWork.UserRepository.GetAll().ToList();
            }
        }
        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                _nameFilter = value;
                using (CP.UnitOfWork.UnitOfWork unitOfWork = new CP.UnitOfWork.UnitOfWork())
                {
                    Users = unitOfWork.UserRepository.GetAll()
                        .Where(a => a.Name.StartsWith(value))
                        .ToList();
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
                    Users = unitOfWork.UserRepository.GetAll()
                        .Where(a => a.IdUser == value)
                        .ToList();
                }
                OnPropertyChanged("IdFilter");
            }
        }
        public List<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedPlane");
            }
        }
    }
}
